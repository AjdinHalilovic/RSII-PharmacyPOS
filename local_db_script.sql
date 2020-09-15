CREATE DATABASE "160048";

-- CONECT TO DATABASE 160048

create table public."Countries"
(
    "Id"              serial       not null
        constraint "PK_Countries"
            primary key,
    "Name"            varchar(100) not null,
    "DeletedDateTime" timestamp
);

alter table public."Countries"
    owner to postgres;

create table public."Cities"
(
    "Id"              serial       not null
        constraint "PK_Cities"
            primary key,
    "CountryId"       integer      not null
        constraint "FK_Cities_Countries_CountryId"
            references public."Countries"
            on delete restrict,
    "Name"            varchar(100) not null,
    "PostalCode"      varchar(20),
    "DeletedDateTime" timestamp
);

alter table public."Cities"
    owner to postgres;

create index "IX_Cities_CountryId"
    on public."Cities" ("CountryId");

create table public."MeasurementUnits"
(
    "Id"              serial not null
        constraint measurementunits_pk
            primary key,
    "Name"            text   not null,
    "DeletedDateTime" timestamp,
    "ShortName"       text   not null
);

alter table public."MeasurementUnits"
    owner to postgres;

create unique index measurementunits_id_uindex
    on public."MeasurementUnits" ("Id");

create table public."Persons"
(
    "Id"              serial not null
        constraint """persons""_pk"
            primary key,
    "FirstName"       text   not null,
    "LastName"        text   not null,
    "DateOfBirth"     timestamp,
    "CountryId"       integer
        constraint "FK_Persons_Countries_CountryId"
            references public."Countries"
            on delete restrict,
    "CityId"          integer
        constraint "FK_Persons_Cities_CityId"
            references public."Cities"
            on delete restrict,
    "Address"         text,
    "Note"            text,
    "DeletedDateTime" timestamp
);

alter table public."Persons"
    owner to postgres;

create unique index """persons""_""id""_uindex"
    on public."Persons" ("Id");

create table public."Roles"
(
    "Id"              serial       not null
        constraint "PK_Roles"
            primary key,
    "Code"            integer      not null,
    "Name"            varchar(100) not null,
    "RoleLevel"       integer,
    "DeletedDateTime" timestamp
);

alter table public."Roles"
    owner to postgres;

create table public."Users"
(
    "Id"                             integer      not null
        constraint "PK_Users"
            primary key
        constraint "FK_Users_Persons_Id"
            references public."Persons"
            on delete restrict,
    "Username"                       text,
    "Email"                          text         not null,
    "Phone"                          text,
    "PasswordHash"                   varchar(100) not null,
    "PasswordSalt"                   varchar(100) not null,
    "CreatedDate"                    timestamp    not null,
    "DeletedDateTime"                timestamp,
    "AccessToken"                    text,
    "TokenExpirationDateTime"        timestamp,
    "RefreshToken"                   text,
    "RefreshTokenExpirationDateTime" timestamp,
    "CreatedTokenDateTime"           timestamp,
    "UpdateDateTime"                 timestamp
);

alter table public."Users"
    owner to postgres;

create table public."Pharmacies"
(
    "Id"                       serial  not null
        constraint pharmacies_pk
            primary key,
    "Name"                     text    not null,
    "PharmacyUniqueIdentifier" text    not null,
    "OwnerUserId"              integer not null
        constraint "FK_Pharmacies_Users_OwnerUserI"
            references public."Users"
            on delete restrict,
    "DeletedDateTime"          timestamp
);

alter table public."Pharmacies"
    owner to postgres;

create unique index pharmacies_id_uindex
    on public."Pharmacies" ("Id");

create unique index pharmacies_name_uindex
    on public."Pharmacies" ("Name");

create unique index pharmacies_pharmacyuniqueidentifier_uindex
    on public."Pharmacies" ("PharmacyUniqueIdentifier");

create table public."PharmacyBranches"
(
    "Id"               serial  not null
        constraint pharmacybranches_pk
            primary key,
    "PharmacyId"       integer not null
        constraint "FK_PharmacyBranches_Pharmacies_PharmacyId"
            references public."Pharmacies"
            on delete restrict,
    "CountryId"        integer not null
        constraint "FK_PharmacyBranches_Countries_CountryId"
            references public."Countries"
            on delete restrict,
    "CityId"           integer not null
        constraint "FK_PharmacyBranches_Cities_CityId"
            references public."Cities"
            on delete restrict,
    "Address"          text,
    "BranchIdentifier" text    not null,
    "Central"          boolean not null,
    "DeletedDateTime"  timestamp
);

alter table public."PharmacyBranches"
    owner to postgres;

create table public."Attributes"
(
    "Id"               serial  not null
        constraint attributes_pk
            primary key,
    "PharmacyBranchId" integer not null
        constraint "FK_Attributes_PharmacyBranches_PharmacyBranchId"
            references public."PharmacyBranches"
            on delete restrict,
    "Name"             text    not null,
    "DeletedDateTime"  timestamp
);

alter table public."Attributes"
    owner to postgres;

create table public."AttributeOptions"
(
    "Id"              serial  not null
        constraint attributeoptions_pk
            primary key,
    "AttributeId"     integer not null
        constraint "FK_AttributeOptions_Attributes_AttributeId"
            references public."Attributes"
            on delete restrict,
    "Value"           text    not null,
    "DeletedDateTime" timestamp
);

alter table public."AttributeOptions"
    owner to postgres;

create unique index attributeoptions_id_uindex
    on public."AttributeOptions" ("Id");

create unique index attributes_id_uindex
    on public."Attributes" ("Id");

create table "public"."Bills"
(
    "Id"               serial    not null
        constraint "bills_pk"
            primary key,
    "PharmacyBranchId" integer   not null
        constraint "FK_Bills_PharmacyBranches_PharmacyBranchId"
            references "public"."PharmacyBranches"
            on delete restrict,
    "Number"           integer   not null,
    "CreatedDateTime"  timestamp not null,
    "CancelDateTime"   timestamp,
    "Total"            numeric   not null,
    "DeletedDateTime"  timestamp,
    "AddUserId"        integer   not null
        constraint "FK_Bills_Users_AddUserId"
            references "public"."Users"
            on delete restrict
);

alter table public."Bills"
    owner to postgres;

create unique index bills_id_uindex
    on public."Bills" ("Id");

create table public."Categories"
(
    "Id"               serial  not null
        constraint categories_pk
            primary key,
    "PharmacyBranchId" integer not null
        constraint "FK_Categories_PharmacyBranches_PharmacyBranchId"
            references public."PharmacyBranches"
            on delete restrict,
    "Name"             text    not null,
    "DeletedDateTime"  timestamp
);

alter table public."Categories"
    owner to postgres;

create unique index categories_id_uindex
    on public."Categories" ("Id");

create table public."Inventories"
(
    "Id"               serial  not null
        constraint inventory_pk
            primary key,
    "PharmacyBranchId" integer not null
        constraint "FK_Inventories_PharmacyBranches_PharmacyBranchId"
            references public."PharmacyBranches"
            on delete restrict,
    "DeletedDateTime"  timestamp
);

alter table public."Inventories"
    owner to postgres;

create unique index inventory_id_uindex
    on public."Inventories" ("Id");

create table public."InventoryEntries"
(
    "Id"              serial    not null
        constraint inventoryentires_pk
            primary key,
    "InventoryId"     integer   not null
        constraint "FK_InventoryEntries_Inventories_InventoryId"
            references public."Inventories"
            on delete restrict,
    "EntryDateTime"   timestamp not null,
    "UserId"          integer   not null
        constraint "FK_InventoryEntires_Users_UserId"
            references public."Users"
            on delete restrict,
    "EntryNumber"     text      not null,
    "DeletedDateTime" timestamp
);

alter table public."InventoryEntries"
    owner to postgres;

create unique index inventoryentires_id_uindex
    on public."InventoryEntries" ("Id");

create table public."InventoryIntermediates"
(
    "Id"              serial    not null
        constraint inventoryintermediates_pk
            primary key,
    "FromInventoryId" integer   not null
        constraint "FK_InventoryIntermediates_Inventories_FromInventoryId"
            references public."Inventories"
            on delete restrict,
    "ToInventoryId"   integer
        constraint "FK_InventoryIntermediates_Inventories_ToInventoryId"
            references public."Inventories"
            on delete restrict,
    "DeletedDateTime" timestamp,
    "CreatedDateTime" timestamp not null,
    "UserId"          integer   not null
        constraint "FK_InventoryIntermediates_Users_UserId"
            references public."Users"
            on delete restrict
);

alter table public."InventoryIntermediates"
    owner to postgres;

create table public."InventoryIntermediateProducts"
(
    "Id"                      serial  not null
        constraint inventoryintermediateproducts_pk
            primary key,
    "InventoryIntermediateId" integer not null
        constraint "FK_InventoryIntermediateProducts_IP_InventoryIntermediateId"
            references public."InventoryIntermediates"
            on delete restrict,
    "ProductId"               integer not null,
    "Quantity"                integer not null,
    "DeletedDateTime"         timestamp
);

alter table public."InventoryIntermediateProducts"
    owner to postgres;

create unique index inventoryintermediateproducts_id_uindex
    on public."InventoryIntermediateProducts" ("Id");

create unique index inventoryintermediates_id_uindex
    on public."InventoryIntermediates" ("Id");

create table public."PharmacyBranchUsers"
(
    "Id"               serial    not null
        constraint pharmacybranchusers_pk
            primary key,
    "PharmacyBranchId" integer   not null
        constraint "FK_PharmacyBranchUsers_PharmacyBranches_PharmacyBranchId"
            references public."PharmacyBranches"
            on delete restrict,
    "UserId"           integer   not null
        constraint "FK_PharmacyBranchUsers_Users_UserId"
            references public."Users"
            on delete restrict,
    "StartDateTime"    timestamp not null,
    "EndDateTime"      timestamp,
    "DeletedDateTime"  timestamp
);

alter table public."PharmacyBranchUsers"
    owner to postgres;

create unique index pharmacybranchusers_id_uindex
    on public."PharmacyBranchUsers" ("Id");

create unique index pharmacybranches_branchidentifier_uindex
    on public."PharmacyBranches" ("BranchIdentifier");

create unique index pharmacybranches_id_uindex
    on public."PharmacyBranches" ("Id");

create table public."Products"
(
    "Id"                serial            not null
        constraint products_pk
            primary key,
    "PharmacyBranchId"  integer           not null
        constraint "FK_Products_PharmacyBranches_PharmacyBranchId"
            references public."PharmacyBranches"
            on delete restrict,
    "Name"              text              not null,
    "Code"              text              not null,
    "Description"       text,
    "DeletedDateTime"   timestamp,
    "MeasurementUnitId" integer           not null
        constraint "FK_Products_MeasurementUnits_MeasurementUnitId"
            references public."MeasurementUnits"
            on delete restrict,
    "Price"             numeric default 0 not null
);

alter table public."Products"
    owner to postgres;

create table public."BillItems"
(
    "Id"              serial  not null
        constraint billitems_pk
            primary key,
    "BillId"          integer not null
        constraint "FK_BillItems_Bills_BillId"
            references public."Bills"
            on delete restrict,
    "ProductId"       integer not null
        constraint "FK_BillITems_Products_ProductId"
            references public."Products"
            on delete restrict,
    "Quantity"        integer not null,
    "UnitPrice"       numeric not null,
    "Total"           numeric not null,
    "DeletedDateTime" timestamp
);

alter table public."BillItems"
    owner to postgres;

create unique index billitems_id_uindex
    on public."BillItems" ("Id");

create table public."InventoryProducts"
(
    "Id"              serial  not null
        constraint inventoryproducts_pk
            primary key,
    "InventoryId"     integer not null
        constraint "FK_InventoryProducts_Inventories_InventoryId"
            references public."Inventories"
            on delete restrict,
    "ProductId"       integer not null
        constraint "FK_InventoryProducts_Products_ProductId"
            references public."Products"
            on delete restrict,
    "Quantity"        numeric not null,
    "DeletedDateTime" timestamp
);

alter table public."InventoryProducts"
    owner to postgres;

create unique index inventoryproducts_id_uindex
    on public."InventoryProducts" ("Id");

create table public."ProductAttributes"
(
    "Id"                serial  not null
        constraint productattributes_pk
            primary key,
    "ProductId"         integer not null
        constraint "FK_ProductAttributes_Products_ProductId"
            references public."Products"
            on delete restrict,
    "AttributeId"       integer not null
        constraint "FK_ProductAttributes_Attributes_AttributeId"
            references public."Attributes"
            on delete restrict,
    "AttributeOptionId" integer not null
        constraint "FK_ProductAttributes_AttributeOptions_AttributeOptionId"
            references public."AttributeOptions"
            on delete restrict,
    "DeletedDateTime"   timestamp
);

alter table public."ProductAttributes"
    owner to postgres;

create unique index productattributes_id_uindex
    on public."ProductAttributes" ("Id");

create table public."ProductCategories"
(
    "Id"              serial  not null
        constraint productcategories_pk
            primary key,
    "ProductId"       integer not null
        constraint "FK_ProductCategories_Products_ProductId"
            references public."Products"
            on delete restrict,
    "CategoryId"      integer not null
        constraint "FK_ProductCategories_Categories_CategoryId"
            references public."Categories"
            on delete restrict,
    "DeletedDateTime" timestamp
);

alter table public."ProductCategories"
    owner to postgres;

create unique index productcategories_id_uindex
    on public."ProductCategories" ("Id");

create unique index products_id_uindex
    on public."Products" ("Id");

create table public."Substances"
(
    "Id"               serial  not null
        constraint substances_pk
            primary key,
    "PharmacyBranchId" integer not null
        constraint "FK_Substances_PharmacyBranches_PharmacyBranchId"
            references public."PharmacyBranches"
            on delete restrict,
    "Name"             text    not null,
    "DeletedDateTime"  timestamp
);

alter table public."Substances"
    owner to postgres;

create table public."ProductSubstances"
(
    "Id"              serial  not null
        constraint productsubstances_pk
            primary key,
    "ProductId"       integer not null
        constraint "FK_ProductSubstances_Products_ProductId"
            references public."Products"
            on delete restrict,
    "SubstanceId"     integer not null
        constraint "FK_ProductSubstances_Substances_SubstanceId"
            references public."Substances"
            on delete restrict,
    "DeletedDateTime" timestamp
);

alter table public."ProductSubstances"
    owner to postgres;

create unique index productsubstances_id_uindex
    on public."ProductSubstances" ("Id");

create table public."ProhibitedSubstances"
(
    "Id"                    serial  not null
        constraint prohibitedsubstances_pk
            primary key,
    "SubstanceId"           integer not null
        constraint "FK_ProhibitedSubstances_Substances_SubstanceId"
            references public."Substances"
            on delete restrict,
    "ProhibitedSubstanceId" integer not null
        constraint "FK_ProhibitedSubstances_Substances_ProhibitedSubstanceId"
            references public."Substances"
            on delete restrict,
    "DeletedDateTime"       timestamp
);

alter table public."ProhibitedSubstances"
    owner to postgres;

create unique index prohibitedsubstances_id_uindex
    on public."ProhibitedSubstances" ("Id");

create unique index substances_id_uindex
    on public."Substances" ("Id");

create table public."UserRoles"
(
    "Id"               serial  not null
        constraint userroles_pk
            primary key,
    "UserId"           integer not null
        constraint "FK_UserRoles_Users_UserId"
            references public."Users"
            on delete restrict,
    "PharmacyId"       integer not null
        constraint "FK_UserRoles_Pharmacies_PharmacyId"
            references public."Pharmacies"
            on delete restrict,
    "PharmacyBranchId" integer
        constraint "FK_UserRoles_PharmacyBranches_PharmacyBranchId"
            references public."PharmacyBranches"
            on delete restrict,
    "DeletedDateTime"  timestamp,
    "RoleId"           integer not null
        constraint "FK_UserRoles_Roles_RoleId"
            references public."Roles"
            on delete restrict
);

alter table public."UserRoles"
    owner to postgres;

create unique index userroles_id_uindex
    on public."UserRoles" ("Id");

create table public."InventoryEntryProducts"
(
    "Id"               serial  not null
        constraint inventoryentryproducts_pk
            primary key,
    "InventoryEntryId" integer not null
        constraint "FK_InventoryEntryProducts_InventoryEntries_InventoryEntryID"
            references public."InventoryEntries"
            on delete restrict,
    "ProductId"        integer not null
        constraint "FK_InventoryEntryProducts_Products_ProductId"
            references public."Products"
            on delete restrict,
    "Quantity"         integer not null,
    "DeletedDateTime"  timestamp
);

alter table public."InventoryEntryProducts"
    owner to postgres;

create unique index inventoryentryproducts_id_uindex
    on public."InventoryEntryProducts" ("Id");

create table public."WriteOffInventoryDocuments"
(
    "Id"                 serial    not null
        constraint writeoffinventorystatuses_pk
            primary key,
    "InventoryProductId" integer   not null
        constraint "FK_WriteOffInventoryDocuments_InventoryProducts_InventoryProduc"
            references public."InventoryProducts"
            on delete restrict,
    "WriteOffDateTime"   timestamp not null,
    "Quantity"           integer   not null,
    "DeletedDateTime"    timestamp,
    "UserId"             integer   not null
        constraint "FK_WriteOffInventoryDocuments_Users_UserId"
            references public."Users"
            on delete restrict,
    "Reason"             text      not null
);

alter table public."WriteOffInventoryDocuments"
    owner to postgres;

create unique index writeoffinventorystatuses_id_uindex
    on public."WriteOffInventoryDocuments" ("Id");




insert into "Countries" ("Id", "Name", "DeletedDateTime") values (1, 'Bosna i Hercegovina', null);
insert into "Cities" ("Id", "CountryId", "Name", "PostalCode", "DeletedDateTime") values (1, 1, 'Sarajevo', 71000, null);
insert into "MeasurementUnits" ("Id", "Name", "DeletedDateTime", "ShortName") values (1, 'Mililiters', null, 'ml');

insert into "Persons" ("Id", "FirstName", "LastName", "DateOfBirth", "CountryId", "CityId", "Address", "Note", "DeletedDateTime") values (1, 'Test', 'Test', '2020-08-12 17:41:28.000000', null, null, null, null, null);
insert into "Persons" ("Id", "FirstName", "LastName", "DateOfBirth", "CountryId", "CityId", "Address", "Note", "DeletedDateTime") values (6, 'Admin', 'Poslovnice', '2020-09-14 14:33:24.807462', 1, 1, 'teeeest', 'dddd', null);
insert into "Persons" ("Id", "FirstName", "LastName", "DateOfBirth", "CountryId", "CityId", "Address", "Note", "DeletedDateTime") values (5, 'Mobile', 'Skladistar', '2020-09-14 12:33:00.000000', 1, 1, 'teeeest', 'dddd', null);
insert into "Persons" ("Id", "FirstName", "LastName", "DateOfBirth", "CountryId", "CityId", "Address", "Note", "DeletedDateTime") values (4, 'Prodavac', 'Apotekar', '2020-09-14 12:31:00.000000', null, 1, 'test', 'test', null);
insert into "Persons" ("Id", "FirstName", "LastName", "DateOfBirth", "CountryId", "CityId", "Address", "Note", "DeletedDateTime") values (3, 'Su', 'Admin', '2020-08-12 09:41:00.000000', 1, 1, 'josanica', '', null);
insert into "Persons" ("Id", "FirstName", "LastName", "DateOfBirth", "CountryId", "CityId", "Address", "Note", "DeletedDateTime") values (9, 'Admin', 'Apoteka 2', null, null, null, null, null, null);


insert into "Roles" ("Id", "Code", "Name", "RoleLevel", "DeletedDateTime") values (1, 1, 'Super administrator', 1, null);
insert into "Roles" ("Id", "Code", "Name", "RoleLevel", "DeletedDateTime") values (2, 2, 'Administrator', 1, null);
insert into "Roles" ("Id", "Code", "Name", "RoleLevel", "DeletedDateTime") values (3, 3, 'Seller', 1, null);
insert into "Roles" ("Id", "Code", "Name", "RoleLevel", "DeletedDateTime") values (4, 4, 'Stockman', 1, null);

insert into "Users" ("Id", "Username", "Email", "Phone", "PasswordHash", "PasswordSalt", "CreatedDate", "DeletedDateTime", "AccessToken", "TokenExpirationDateTime", "RefreshToken", "RefreshTokenExpirationDateTime", "CreatedTokenDateTime", "UpdateDateTime") values (1, 'test', 'test@"Email".ba', 000, 'test', 'test', '2020-08-12 17:41:06.000000', null, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJQZXJzb24iOiIxIiwibmJmIjoxNTk3MjQ4NjUyLCJleHAiOjE1OTcyNDk4NTIsImlhdCI6MTU5NzI0ODY1MiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzNzAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0NDM3MCJ9.dbkEXlwqPL3d9Os95epRIJl6WfJ0YujQdelAiBilESA', '2020-08-12 18:30:52.656717', 'wXxz+rgdV8yO3AG9I7o1DMtX8w5B3TqqFb8LBsgNzpE=', '2020-08-13 18:10:52.657269', '2020-08-12 18:10:52.657369', null);
insert into "Users" ("Id", "Username", "Email", "Phone", "PasswordHash", "PasswordSalt", "CreatedDate", "DeletedDateTime", "AccessToken", "TokenExpirationDateTime", "RefreshToken", "RefreshTokenExpirationDateTime", "CreatedTokenDateTime", "UpdateDateTime") values (4, 'desktopSeller', 'desktopSeller@hotmail.com', 066268485, 'u2NAwiPA4IjCW7xjIdJNA+4pA+KYDBqaOK+5EaDu+LY=', 'KnCwD8a7QulejWLY0gnqZQ==', '0001-01-01 00:00:00.000000', null, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiI0IiwiUGhhcm1hY3lJZCI6IjIiLCJQaGFybWFjeUJyYW5jaElkIjoiMiIsIkludmVudG9yeUlkIjoiMSIsIkxpc3QiOiJbe1wiSWRcIjo0LFwiVXNlcklkXCI6NCxcIlBoYXJtYWN5SWRcIjoyLFwiUGhhcm1hY3lCcmFuY2hJZFwiOjIsXCJSb2xlSWRcIjozLFwiRGVsZXRlZERhdGVUaW1lXCI6bnVsbCxcIlVzZXJcIjpudWxsLFwiUGhhcm1hY3lcIjpudWxsLFwiUGhhcm1hY3lCcmFuY2hcIjpudWxsLFwiUm9sZVwiOntcIklkXCI6MyxcIkNvZGVcIjozLFwiTmFtZVwiOlwiU2VsbGVyXCIsXCJSb2xlTGV2ZWxcIjoxLFwiRGVsZXRlZERhdGVUaW1lXCI6bnVsbH19XSIsIm5iZiI6MTYwMDA5NDY5MiwiZXhwIjoxNjAwMDk1ODkyLCJpYXQiOjE2MDAwOTQ2OTIsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzcwIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzNzAifQ.zUfD1vVDlZwGTmxOyJPq51WvXyWXzmLhcIV4f3QjvYw', '2020-09-14 17:04:53.096404', '4Zysu0TjNSbZJbqkosLWTRikmf65eRWa/HhzVg2CyTo=', '2020-09-15 16:44:53.097286', '2020-09-14 16:44:53.097472', '2020-09-14 14:36:45.461732');
insert into "Users" ("Id", "Username", "Email", "Phone", "PasswordHash", "PasswordSalt", "CreatedDate", "DeletedDateTime", "AccessToken", "TokenExpirationDateTime", "RefreshToken", "RefreshTokenExpirationDateTime", "CreatedTokenDateTime", "UpdateDateTime") values (5, 'mobileStockman', 'mobileStockman@gmail.com', 062548556, 'u2NAwiPA4IjCW7xjIdJNA+4pA+KYDBqaOK+5EaDu+LY=', 'KnCwD8a7QulejWLY0gnqZQ==', '0001-01-01 00:00:00.000000', null, null, null, null, null, null, '2020-09-14 14:36:12.686644');
insert into "Users" ("Id", "Username", "Email", "Phone", "PasswordHash", "PasswordSalt", "CreatedDate", "DeletedDateTime", "AccessToken", "TokenExpirationDateTime", "RefreshToken", "RefreshTokenExpirationDateTime", "CreatedTokenDateTime", "UpdateDateTime") values (6, 'desktop', 'destktop@gmail.com', 061112335, 'u2NAwiPA4IjCW7xjIdJNA+4pA+KYDBqaOK+5EaDu+LY=', 'KnCwD8a7QulejWLY0gnqZQ==', '0001-01-01 00:00:00.000000', null, null, null, null, null, null, null);
insert into "Users" ("Id", "Username", "Email", "Phone", "PasswordHash", "PasswordSalt", "CreatedDate", "DeletedDateTime", "AccessToken", "TokenExpirationDateTime", "RefreshToken", "RefreshTokenExpirationDateTime", "CreatedTokenDateTime", "UpdateDateTime") values (9, 'admin2', 'admin2@ggmail.com', null, 'u2NAwiPA4IjCW7xjIdJNA+4pA+KYDBqaOK+5EaDu+LY=', 'KnCwD8a7QulejWLY0gnqZQ==', '2020-09-14 21:07:57.749753', null, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiI5IiwiUGhhcm1hY3lJZCI6IjIiLCJQaGFybWFjeUJyYW5jaElkIjoiNCIsIkludmVudG9yeUlkIjoiMiIsIkxpc3QiOiJbe1wiSWRcIjo3LFwiVXNlcklkXCI6OSxcIlBoYXJtYWN5SWRcIjoyLFwiUGhhcm1hY3lCcmFuY2hJZFwiOjQsXCJSb2xlSWRcIjoyLFwiRGVsZXRlZERhdGVUaW1lXCI6bnVsbCxcIlVzZXJcIjpudWxsLFwiUGhhcm1hY3lcIjpudWxsLFwiUGhhcm1hY3lCcmFuY2hcIjpudWxsLFwiUm9sZVwiOntcIklkXCI6MixcIkNvZGVcIjoyLFwiTmFtZVwiOlwiQWRtaW5pc3RyYXRvclwiLFwiUm9sZUxldmVsXCI6MSxcIkRlbGV0ZWREYXRlVGltZVwiOm51bGx9fV0iLCJuYmYiOjE2MDAxMTA1ODUsImV4cCI6MTYwMDExMTc4NSwiaWF0IjoxNjAwMTEwNTg1LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo0NDM3MCIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzcwIn0.x2n4KA888x_Gtah3SYNf3V04-hupzCo77pOoeNBWYO8', '2020-09-14 21:29:45.982972', 'HeLnvmUCMQxpc8yJSRf989MMemu6ndX93Ffx5/IJMRQ=', '2020-09-15 21:09:45.983433', '2020-09-14 21:09:45.983635', null);
insert into "Users" ("Id", "Username", "Email", "Phone", "PasswordHash", "PasswordSalt", "CreatedDate", "DeletedDateTime", "AccessToken", "TokenExpirationDateTime", "RefreshToken", "RefreshTokenExpirationDateTime", "CreatedTokenDateTime", "UpdateDateTime") values (3, 'admin', 'su.desktop@"Email"', 060222333, 'u2NAwiPA4IjCW7xjIdJNA+4pA+KYDBqaOK+5EaDu+LY=', 'KnCwD8a7QulejWLY0gnqZQ==', '2020-08-14 16:30:20.650927', null, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIzIiwiUGhhcm1hY3lJZCI6IjIiLCJQaGFybWFjeUJyYW5jaElkIjoiMiIsIkludmVudG9yeUlkIjoiMSIsIkxpc3QiOiJbe1wiSWRcIjozLFwiVXNlcklkXCI6MyxcIlBoYXJtYWN5SWRcIjoyLFwiUGhhcm1hY3lCcmFuY2hJZFwiOjIsXCJSb2xlSWRcIjoxLFwiRGVsZXRlZERhdGVUaW1lXCI6bnVsbCxcIlVzZXJcIjpudWxsLFwiUGhhcm1hY3lcIjpudWxsLFwiUGhhcm1hY3lCcmFuY2hcIjpudWxsLFwiUm9sZVwiOntcIklkXCI6MSxcIkNvZGVcIjoxLFwiTmFtZVwiOlwiU3VwZXIgYWRtaW5pc3RyYXRvclwiLFwiUm9sZUxldmVsXCI6MSxcIkRlbGV0ZWREYXRlVGltZVwiOm51bGx9fV0iLCJuYmYiOjE2MDAxMDcxMTMsImV4cCI6MTYwMDEwODMxMywiaWF0IjoxNjAwMTA3MTEzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo0NDM3MCIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzcwIn0.NUKELUHF1KVI3moUwSCaWlEq1L_7kT1EhhWvz7chPh8', '2020-09-14 20:31:54.103854', 'XvBn/n2QpxLLoZ/XTcGxl13if3+H41wMiCuZZbomohA=', '2020-09-15 20:11:54.104497', '2020-09-14 20:11:54.104603', '2020-09-14 14:37:32.214073');

insert into "Pharmacies" ("Id", "Name", "PharmacyUniqueIdentifier", "OwnerUserId", "DeletedDateTime") values (2, 'Apoteka demo', 000, 3, null);

insert into "PharmacyBranches" ("Id", "PharmacyId", "CountryId", "CityId", "Address", "BranchIdentifier", "Central", "DeletedDateTime") values (2, 2, 1, 1, 'adresa demo', '000-1', 'true', null);
insert into "PharmacyBranches" ("Id", "PharmacyId", "CountryId", "CityId", "Address", "BranchIdentifier", "Central", "DeletedDateTime") values (4, 2, 1, 1, 'test', '000 - 2', 'false', null);

insert into "Attributes" ("Id", "PharmacyBranchId", "Name", "DeletedDateTime") values (1, 2, 'Boja', null);
insert into "Attributes" ("Id", "PharmacyBranchId", "Name", "DeletedDateTime") values (2, 2, 'Prirodno stanje', null);

insert into "AttributeOptions" ("Id", "AttributeId", "Value", "DeletedDateTime") values (1, 1, 'Plava', null);
insert into "AttributeOptions" ("Id", "AttributeId", "Value", "DeletedDateTime") values (2, 1, 'Zuta', null);
insert into "AttributeOptions" ("Id", "AttributeId", "Value", "DeletedDateTime") values (3, 2, 'Prah', null);
insert into "AttributeOptions" ("Id", "AttributeId", "Value", "DeletedDateTime") values (5, 2, 'Tecnost', null);
insert into "AttributeOptions" ("Id", "AttributeId", "Value", "DeletedDateTime") values (4, 2, 'Mast', '2020-08-20 13:29:17.898186');
insert into "AttributeOptions" ("Id", "AttributeId", "Value", "DeletedDateTime") values (6, 2, 'Kapsule', null);

insert into "Categories" ("Id", "PharmacyBranchId", "Name", "DeletedDateTime") values (1, 2, 'Kreme', null);
insert into "Categories" ("Id", "PharmacyBranchId", "Name", "DeletedDateTime") values (2, 2, 'Maze', null);

insert into "Inventories" ("Id", "PharmacyBranchId", "DeletedDateTime") values (1, 2, null);
insert into "Inventories" ("Id", "PharmacyBranchId", "DeletedDateTime") values (2, 4, null);

insert into "InventoryEntries" ("Id", "InventoryId", "EntryDateTime", "UserId", "EntryNumber", "DeletedDateTime") values (4, 1, '2020-09-13 15:15:48.782634', 3, 1234, null);
insert into "InventoryEntries" ("Id", "InventoryId", "EntryDateTime", "UserId", "EntryNumber", "DeletedDateTime") values (5, 1, '2020-09-13 15:18:51.461879', 3, 153548, null);

insert into "PharmacyBranchUsers" ("Id", "PharmacyBranchId", "UserId", "StartDateTime", "EndDateTime", "DeletedDateTime") values (1, 2, 3, '2020-08-14 16:30:20.779759', null, null);
insert into "PharmacyBranchUsers" ("Id", "PharmacyBranchId", "UserId", "StartDateTime", "EndDateTime", "DeletedDateTime") values (2, 2, 4, '2020-09-14 14:33:17.164428', null, null);
insert into "PharmacyBranchUsers" ("Id", "PharmacyBranchId", "UserId", "StartDateTime", "EndDateTime", "DeletedDateTime") values (3, 2, 5, '2020-09-14 14:34:32.246595', null, null);
insert into "PharmacyBranchUsers" ("Id", "PharmacyBranchId", "UserId", "StartDateTime", "EndDateTime", "DeletedDateTime") values (4, 2, 6, '2020-09-14 14:35:41.999960', null, null);
insert into "PharmacyBranchUsers" ("Id", "PharmacyBranchId", "UserId", "StartDateTime", "EndDateTime", "DeletedDateTime") values (5, 4, 9, '2020-09-14 21:08:08.677113', null, null);

insert into "Products" ("Id", "PharmacyBranchId", "Name", "Code", "Description", "DeletedDateTime", "MeasurementUnitId", "Price") values (1, 2, 'Tablete', 00001, 'tabletice', null, 1, 7.5);
insert into "Products" ("Id", "PharmacyBranchId", "Name", "Code", "Description", "DeletedDateTime", "MeasurementUnitId", "Price") values (2, 2, 'Lakaluk', '"Code" 0012', 'desc', null, 1, 5);
insert into "Products" ("Id", "PharmacyBranchId", "Name", "Code", "Description", "DeletedDateTime", "MeasurementUnitId", "Price") values (3, 2, 'Paracetamol', 'PC', 'desc', null, 1, 2.5);

insert into "InventoryProducts" ("Id", "InventoryId", "ProductId", "Quantity", "DeletedDateTime") values (1, 1, 2, 10, null);
insert into "InventoryProducts" ("Id", "InventoryId", "ProductId", "Quantity", "DeletedDateTime") values (3, 1, 1, 12, null);
insert into "InventoryProducts" ("Id", "InventoryId", "ProductId", "Quantity", "DeletedDateTime") values (2, 1, 3, 16, null);

insert into "ProductAttributes" ("Id", "ProductId", "AttributeId", "AttributeOptionId", "DeletedDateTime") values (1, 1, 1, 1, null);
insert into "ProductAttributes" ("Id", "ProductId", "AttributeId", "AttributeOptionId", "DeletedDateTime") values (2, 2, 1, 1, '2020-08-20 12:31:10.109881');
insert into "ProductAttributes" ("Id", "ProductId", "AttributeId", "AttributeOptionId", "DeletedDateTime") values (3, 2, 1, 2, null);
insert into "ProductAttributes" ("Id", "ProductId", "AttributeId", "AttributeOptionId", "DeletedDateTime") values (4, 3, 1, 2, null);

insert into "ProductCategories" ("Id", "ProductId", "CategoryId", "DeletedDateTime") values (1, 1, 1, null);
insert into "ProductCategories" ("Id", "ProductId", "CategoryId", "DeletedDateTime") values (2, 2, 2, '2020-08-20 12:14:00.718086');
insert into "ProductCategories" ("Id", "ProductId", "CategoryId", "DeletedDateTime") values (3, 2, 1, '2020-08-20 12:22:18.757344');
insert into "ProductCategories" ("Id", "ProductId", "CategoryId", "DeletedDateTime") values (4, 3, 1, null);
insert into "ProductCategories" ("Id", "ProductId", "CategoryId", "DeletedDateTime") values (5, 3, 2, null);

insert into "Substances" ("Id", "PharmacyBranchId", "Name", "DeletedDateTime") values (1, 2, 'Substanca test', null);
insert into "Substances" ("Id", "PharmacyBranchId", "Name", "DeletedDateTime") values (2, 2, 'Sulfat', null);
insert into "Substances" ("Id", "PharmacyBranchId", "Name", "DeletedDateTime") values (4, 2, 'Aminokiselina C193', null);
insert into "Substances" ("Id", "PharmacyBranchId", "Name", "DeletedDateTime") values (3, 2, 'Nitrat', null);

insert into "ProductSubstances" ("Id", "ProductId", "SubstanceId", "DeletedDateTime") values (1, 1, 1, null);
insert into "ProductSubstances" ("Id", "ProductId", "SubstanceId", "DeletedDateTime") values (2, 2, 1, '2020-08-20 12:14:04.285717');
insert into "ProductSubstances" ("Id", "ProductId", "SubstanceId", "DeletedDateTime") values (3, 2, 1, null);
insert into "ProductSubstances" ("Id", "ProductId", "SubstanceId", "DeletedDateTime") values (4, 3, 1, null);
insert into "ProductSubstances" ("Id", "ProductId", "SubstanceId", "DeletedDateTime") values (5, 3, 1, null);

insert into "ProhibitedSubstances" ("Id", "SubstanceId", "ProhibitedSubstanceId", "DeletedDateTime") values (1, 4, 3, '2020-09-14 14:12:17.465387');
insert into "ProhibitedSubstances" ("Id", "SubstanceId", "ProhibitedSubstanceId", "DeletedDateTime") values (2, 4, 3, null);
insert into "ProhibitedSubstances" ("Id", "SubstanceId", "ProhibitedSubstanceId", "DeletedDateTime") values (3, 3, 4, null);

insert into "UserRoles" ("Id", "UserId", "PharmacyId", "PharmacyBranchId", "DeletedDateTime", "RoleId") values (3, 3, 2, 2, null, 1);
insert into "UserRoles" ("Id", "UserId", "PharmacyId", "PharmacyBranchId", "DeletedDateTime", "RoleId") values (4, 4, 2, 2, null, 3);
insert into "UserRoles" ("Id", "UserId", "PharmacyId", "PharmacyBranchId", "DeletedDateTime", "RoleId") values (5, 5, 2, 2, null, 4);
insert into "UserRoles" ("Id", "UserId", "PharmacyId", "PharmacyBranchId", "DeletedDateTime", "RoleId") values (6, 6, 2, 2, null, 2);
insert into "UserRoles" ("Id", "UserId", "PharmacyId", "PharmacyBranchId", "DeletedDateTime", "RoleId") values (7, 9, 2, 4, null, 2);

insert into "InventoryEntryProducts" ("Id", "InventoryEntryId", "ProductId", "Quantity", "DeletedDateTime") values (3, 4, 3, 25, null);
insert into "InventoryEntryProducts" ("Id", "InventoryEntryId", "ProductId", "Quantity", "DeletedDateTime") values (4, 5, 1, 15, null);
insert into "InventoryEntryProducts" ("Id", "InventoryEntryId", "ProductId", "Quantity", "DeletedDateTime") values (5, 4, 2, 10, null);

insert into "WriteOffInventoryDocuments" ("Id", "InventoryProductId", "WriteOffDateTime", "Quantity", "DeletedDateTime", "UserId", "Reason") values (1, 2, '2020-09-13 20:53:31.538176', 2, null, 3, 'Isteko rok');
insert into "WriteOffInventoryDocuments" ("Id", "InventoryProductId", "WriteOffDateTime", "Quantity", "DeletedDateTime", "UserId", "Reason") values (2, 2, '2020-09-13 20:56:22.613651', 4, null, 3, 'Rok opet');

insert into "Bills" ("Id", "PharmacyBranchId", "Number", "CreatedDateTime", "CancelDateTime", "Total", "DeletedDateTime", "AddUserId") values (1, 2, 0, '2020-09-14 11:34:46.706762', null, 10, null, 3);
insert into "Bills" ("Id", "PharmacyBranchId", "Number", "CreatedDateTime", "CancelDateTime", "Total", "DeletedDateTime", "AddUserId") values (2, 2, 1, '2020-09-15 11:37:31.439415', null, 12.5, null, 3);
insert into "Bills" ("Id", "PharmacyBranchId", "Number", "CreatedDateTime", "CancelDateTime", "Total", "DeletedDateTime", "AddUserId") values (3, 2, 2, '2020-09-19 12:07:16.919529', null, 5, null, 4);

insert into "BillItems" ("Id", "BillId", "ProductId", "Quantity", "UnitPrice", "Total", "DeletedDateTime") values (1, 1, 2, 2, 5, 10, null);
insert into "BillItems" ("Id", "BillId", "ProductId", "Quantity", "UnitPrice", "Total", "DeletedDateTime") values (2, 2, 2, 1, 5, 5, null);
insert into "BillItems" ("Id", "BillId", "ProductId", "Quantity", "UnitPrice", "Total", "DeletedDateTime") values (3, 2, 1, 1, 7.5, 7.5, null);
insert into "BillItems" ("Id", "BillId", "ProductId", "Quantity", "UnitPrice", "Total", "DeletedDateTime") values (4, 3, 3, 2, 2.5, 5, null);


create function "public"."fn_users_getloginbyusertokens"("pAccessToken" text, "pRefreshToken" text)
    returns TABLE
            (
                "Id"          integer,
                "AccessToken" text,
                "UserId"      integer
            )
    language "plpgsql"
as
$$
BEGIN
    RETURN QUERY
        SELECT "U"."Id",
               "U"."AccessToken",
               "U"."Id" AS "UserId"
        FROM "Users" AS "U"
        WHERE "U"."DeletedDateTime" IS NULL
          AND CURRENT_TIMESTAMP < "U"."RefreshTokenExpirationDateTime"
          AND "U"."AccessToken"::TEXT = "pAccessToken"
          AND "U"."RefreshToken"::TEXT = "pRefreshToken";


END;
$$;

alter function "public"."fn_users_getloginbyusertokens"(text, text) owner to "postgres";

create function "public"."fn_users_getloginbyuserid"("pUserId" integer)
    returns TABLE
            (
                "Id"               integer,
                "PharmacyId"       integer,
                "PharmacyBranchId" integer,
                "InventoryId"      integer,
                "AccessToken"      text,
                "UserId"           integer,
                "Active"           boolean,
                "UserFullName"     text
            )
    language "plpgsql"
as
$$
BEGIN
    RETURN QUERY
        SELECT "U"."Id",
               "PharmacyBranch"."PharmacyId",
               "PharmacyBranch"."PharmacyBranchId",
               "PharmacyBranch"."InventoryId",
               "U"."AccessToken",
               "U"."Id"                                           AS "UserId",
               "U"."DeletedDateTime" IS NULL                      AS "Active",
               concat("P"."FirstName", ' ', "P"."LastName")::TEXT AS "UserFullName"
        FROM "Users" AS "U"
                 LEFT JOIN LATERAL (
            SELECT "PBU"."PharmacyBranchId", "PB"."PharmacyId", "I"."Id" AS "InventoryId"
            FROM "PharmacyBranchUsers" AS "PBU"
                     JOIN "PharmacyBranches" AS "PB" ON "PBU"."PharmacyBranchId" = "PB"."Id"
                     JOIN "Inventories" AS "I" ON "PB"."Id" = "I"."PharmacyBranchId"
            WHERE "PBU"."UserId" = "U"."Id"
              AND "PBU"."EndDateTime" IS NULL
              AND "PBU"."DeletedDateTime" IS NULL
              AND "PB"."DeletedDateTime" IS NULL
              AND "I"."DeletedDateTime" IS NULL
            LIMIT 1
            ) AS "PharmacyBranch" ON TRUE
                 JOIN "Persons" AS "P" ON "P"."Id" = "U"."Id"
        WHERE "U"."Id" = "pUserId";


END;
$$;

alter function "public"."fn_users_getloginbyuserid"(integer) owner to "postgres";

create function "public"."fn_persons_getdtosbyparameters"("pFullName" text, "pPharmacyBranchId" integer)
    returns TABLE
            (
                "Id"          integer,
                "FullName"    text,
                "DateOfBirth" timestamp without time zone,
                "Email"       text,
                "Phone"       text,
                "Country"     text,
                "City"        text,
                "Address"     text
            )
    language "plpgsql"
as
$$
BEGIN
    RETURN QUERY
        SELECT "P"."Id",
               concat("P"."FirstName", ' ', "P"."LastName")::TEXT AS "FullName",
               "P"."DateOfBirth",
               "U"."Email",
               "U"."Phone",
               "CT"."Name"::TEXT                                  AS "Country",
               "C"."Name"::TEXT                                   AS "City",
               "P"."Address"
        FROM "Persons" AS "P"
                 JOIN "Users" AS "U" ON "P"."Id" = "U"."Id"
                 JOIN "PharmacyBranchUsers" AS "PBU" ON "U"."Id" = "PBU"."UserId"
                 LEFT JOIN "Countries" AS "CT" ON "P"."CountryId" = "CT"."Id"
                 LEFT JOIN "Cities" AS "C" ON "P"."CityId" = "C"."Id"
        WHERE "P"."DeletedDateTime" IS NULL
          AND ("pFullName" IS NULL OR
               LOWER(CONCAT("P"."FirstName", ' ', "P"."LastName")) @@ to_tsquery(LOWER("pFullName")))
          AND "PBU"."EndDateTime" IS NULL
          AND "PBU"."DeletedDateTime" IS NULL
          AND "PBU"."PharmacyBranchId" = "pPharmacyBranchId";


END;
$$;

alter function "public"."fn_persons_getdtosbyparameters"(text, integer) owner to "postgres";

create function "public"."fn_products_getdtosbyparameters"("pPharmacyBranchId" integer, "pSearchTerm" text,
                                                           "pCategoryId" integer)
    returns TABLE
            (
                "Id"               integer,
                "Name"             text,
                "Code"             text,
                "Description"      text,
                "MeasurementUnit"  text,
                "Categories"       text,
                "SubstancesNumber" integer,
                "AttributeNumber"  integer,
                "Quantity"         numeric,
                "Price"            numeric
            )
    language "plpgsql"
as
$$
BEGIN
    RETURN QUERY
        SELECT "P"."Id",
               "P"."Name",
               "P"."Code",
               "P"."Description",
               "MU"."Name" AS "MeasurementUnit",
               "FormatedCategories"."Categories",
               "ProductSubstance"."SubstancesNumber",
               "ProductAttribute"."AttributeNumber",
               "Inventory"."Quantity",
               "P"."Price"
        FROM "Products" AS "P"
                 LEFT JOIN "MeasurementUnits" AS "MU" ON "P"."MeasurementUnitId" = "MU"."Id"
                 LEFT JOIN LATERAL (
            SELECT string_agg("C"."Name", ', ')::TEXT AS "Categories"
            FROM "ProductCategories" AS "PC"
                     JOIN "Categories" "C" on "PC"."CategoryId" = "C"."Id"
            WHERE "PC"."DeletedDateTime" IS NULL
              AND "PC"."ProductId" = "P"."Id"
              AND ("PC"."CategoryId" = "pCategoryId" OR "pCategoryId" IS NULL)
            ) AS "FormatedCategories" ON TRUE
                 LEFT JOIN LATERAL (
            SELECT COUNT(*)::INTEGER AS "SubstancesNumber"
            FROM "ProductSubstances" AS "PS"
            WHERE "PS"."DeletedDateTime" IS NULL
              AND "PS"."ProductId" = "P"."Id"
            ) AS "ProductSubstance" ON TRUE
                 LEFT JOIN LATERAL (
            SELECT COUNT(*)::INTEGER AS "AttributeNumber"
            FROM "ProductAttributes" AS "PA"
            WHERE "PA"."DeletedDateTime" IS NULL
              AND "PA"."ProductId" = "P"."Id"
            ) AS "ProductAttribute" ON TRUE
                 LEFT JOIN LATERAL (
            SELECT "IP"."Quantity"
            FROM "InventoryProducts" AS "IP"
            WHERE "IP"."DeletedDateTime" IS NULL
              AND "IP"."ProductId" = "P"."Id"
            LIMIT 1
            ) AS "Inventory" ON TRUE
        WHERE "P"."DeletedDateTime" IS NULL
          AND "P"."PharmacyBranchId" = "pPharmacyBranchId"
          AND ("pSearchTerm" IS NULL OR LOWER("P"."Name") @@ to_tsquery(LOWER("pSearchTerm")))
          AND ("pCategoryId" IS NULL OR ("pCategoryId" IS NOT NULL AND "FormatedCategories"."Categories" IS NOT NULL));


END;
$$;

alter function "public"."fn_products_getdtosbyparameters"(integer, text, integer) owner to "postgres";

create function "public"."fn_inventoryentries_getdtosbyparameters"("pPharmacyBranchId" integer, "pSearchTerm" text)
    returns TABLE
            (
                "Id"            integer,
                "EntryNumber"   text,
                "EntryDateTime" timestamp without time zone,
                "FullName"      text
            )
    language "plpgsql"
as
$$
BEGIN
    RETURN QUERY
        SELECT "IE"."Id",
               "IE"."EntryNumber",
               "IE"."EntryDateTime",
               concat("P"."FirstName", ' ', "P"."LastName")::TEXT AS "FullName"
        FROM "InventoryEntries" AS "IE"
                 JOIN "Inventories" AS "I" ON "IE"."InventoryId" = "I"."Id"
                 JOIN "Users" AS "U" ON "IE"."UserId" = "U"."Id"
                 JOIN "Persons" AS "P" ON "U"."Id" = "P"."Id"
        WHERE "IE"."DeletedDateTime" IS NULL
          AND "I"."PharmacyBranchId" = "pPharmacyBranchId"
          AND ("pSearchTerm" IS NULL OR LOWER("IE"."EntryNumber") @@ to_tsquery(LOWER("pSearchTerm")));


END;
$$;

alter function "public"."fn_inventoryentries_getdtosbyparameters"(integer, text) owner to "postgres";

create function "public"."fn_productsubstances_anyprohibitedsubstance"("pProductId" integer, "pProductIds" text) returns boolean
    language "plpgsql"
as
$$
BEGIN

    RETURN EXISTS
        (
            SELECT "PHS"."Id"
            FROM "ProductSubstances" AS "PS"
                     JOIN "Substances" AS "S" ON "PS"."SubstanceId" = "S"."Id"
                     JOIN "ProhibitedSubstances" AS "PHS"
                          ON "S"."Id" = "PHS"."ProhibitedSubstanceId" OR "S"."Id" = "PHS"."SubstanceId"
                     LEFT JOIN LATERAL (
                SELECT "PHS2"."Id"
                FROM "ProhibitedSubstances" AS "PHS2"
                         JOIN "Substances" "S2"
                              on "PHS2"."ProhibitedSubstanceId" = "S2"."Id" OR "PHS2"."SubstanceId" = "S2"."Id"
                         JOIN "ProductSubstances" AS "PS2" ON "PS2"."SubstanceId" = "S2"."Id"
                WHERE "PS2"."ProductId" IN
                      (SELECT "regexp_split_to_table"::int FROM regexp_split_to_table("pProductIds", ','))
                  AND ("PHS"."SubstanceId" = "S2"."Id" OR "PHS"."ProhibitedSubstanceId" = "S2"."Id")
                LIMIT 1
                ) AS "Prohibited" ON TRUE
            WHERE "PS"."ProductId" = "pProductId"
              AND "PS"."DeletedDateTime" IS NULL
              AND "Prohibited"."Id" IS NOT NULL
        );

END;
$$;

alter function "public"."fn_productsubstances_anyprohibitedsubstance"(integer, text) owner to "postgres";

