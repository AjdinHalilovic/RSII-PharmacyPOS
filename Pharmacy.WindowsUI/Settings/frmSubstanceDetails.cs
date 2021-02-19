using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models;
using Pharmacy.Core.Models.Billing;
using Pharmacy.Core.Models.Settings;
using Pharmacy.Core.Models.Settins;
using Pharmacy.WindowsUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy.WindowsUI.Settings
{
    public partial class frmSubstanceDetails : Form
    {
        private readonly APIService _aPIServiceSubstances = new APIService("Substances");
        private readonly APIService _aPIServiceProhibitedSubstances = new APIService("ProhibitedSubstances");

        private int? _id = null;
        public frmSubstanceDetails(int? id = null)
        {
            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
            _id = id;
        }

        private async void frmCategoryDetails_LoadAsync(object sender, EventArgs e)
        {
            var substances = await _aPIServiceSubstances.Get<List<Substance>>(null);
            if (_id.HasValue)
            {
                var substance = await _aPIServiceSubstances.GetById<Substance>(_id);
                txtName.Text = substance.Name;

                var prohibitedSubstance = (await _aPIServiceProhibitedSubstances.Get<List<ProhibitedSubstance>>(new ProhibitedSubstanceSearchObject() { SubstanceId = _id })).ToList();
                prohibitedSubstance.AddRange((await _aPIServiceProhibitedSubstances.Get<List<ProhibitedSubstance>>(new ProhibitedSubstanceSearchObject() { ProhibitedSubstanceId = _id })).ToList());

                List<int> prohibitedIds = new List<int>();
                prohibitedIds.AddRange(prohibitedSubstance.Where(x => x.SubstanceId == _id).Select(x => x.ProhibitedSubstanceId).ToList());
                prohibitedIds.AddRange(prohibitedSubstance.Where(x => x.ProhibitedSubstanceId == _id).Select(x => x.SubstanceId).ToList());

                var selectedSubstances = await _aPIServiceSubstances.Get<List<Substance>>(new SubstanceSearchObject() { ListIds = prohibitedIds.Distinct().ToList().Count > 0 ? prohibitedIds.ToArray() : new int[] { 0 } });
                substances = substances.Where(x => !selectedSubstances.Select(y => y.Id).Contains(x.Id)).ToList();
                selectedSubstances.ToList().ForEach(x => clbProhibitedSubstances.Items.Add(x, true));
            }
            substances.ToList().ForEach(x => clbProhibitedSubstances.Items.Add(x));
            clbProhibitedSubstances.DisplayMember = "Name";
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtName, null);
            }
        }

        private async void btnSave_ClickAsync(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                var existingSubstance = await _aPIServiceSubstances.Get<IEnumerable<BaseDto>>(new SubstanceSearchObject { EqualSearchTerm = txtName.Text });
                if (existingSubstance.Any() && !_id.HasValue)
                {
                    MessageBox.Show("Substance already exists!", "Error");
                    return;
                }
            }
            if (ValidateChildren())
            {
                try
                {
                    var substancesList = clbProhibitedSubstances.CheckedItems.Cast<Substance>().Select(x => x.Id).ToList();

                    SubstanceUpsertRequest request = new SubstanceUpsertRequest()
                    {
                        Name = txtName.Text,
                        Substances = substancesList
                    };

                    Substance substance = null;

                    if (!_id.HasValue)
                    {
                        substance = await _aPIServiceSubstances.Insert<Substance>(request);
                    }
                    else
                    {
                        substance = await _aPIServiceSubstances.Update<Substance>(_id.Value, request);
                    }

                    if (substance != null)
                    {
                        MessageBox.Show("Successfully saved!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                    throw;
                }
            }
        }
    }
}
