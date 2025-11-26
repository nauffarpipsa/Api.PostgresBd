using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entidades.db
{

    [Table("sap_maestro_cuentas_bancarias")]
    public class sap_maestro_cuentas_bancarias
    {

        [Key]
        [Column("id")]
        public string? Id { get; set; }

        [Column("language_code_text")]
        public string? LanguageCodeText { get; set; }

        [Column("currency_code_text")]
        public string? CurrencyCodeText { get; set; }

        [Column("internal_id")]
        public string? InternalId { get; set; }

        [Column("uuid1")]
        public string? Uuid1 { get; set; }

        [Column("bank_group_code")]
        public string? BankGroupCode { get; set; }

        [Column("object_id")]
        public string? ObjectId { get; set; }

        [Column("bank_directory_entry_uuid")]
        public string? BankDirectoryEntryUuid { get; set; }

        [Column("country_code_text")]
        public string? CountryCodeText { get; set; }

        [Column("last_change_identity_uuid")]
        public string? LastChangeIdentityUuid { get; set; }

        [Column("start_date")]
        public string? StartDate { get; set; }

        [Column("currency_code")]
        public string? CurrencyCode { get; set; }

        [Column("id_company")]
        public string IdCompany { get; set; }

        [Column("bank_standard_id")]
        public string? BankStandardId { get; set; }

        [Column("creation_identity_uuid")]
        public string? CreationIdentityUuid { get; set; }

        [Column("bank_account_id")]
        public string? BankAccountId { get; set; }

        [Column("payment_medium_format_code1")]
        public string? PaymentMediumFormatCode1 { get; set; }

        [Column("description")]
        public string? Descripcion { get; set; }

        [Column("internal_id1")]
        public string? InternalId1 { get; set; }

        [Column("bank_group_code_text")]
        public string? BankGroupCodeText { get; set; }

        [Column("uuid")]
        public string? Uuid { get; set; }

        [Column("country_code")]
        public string? CountryCode { get; set; }

        [Column("life_cycle_status_code1")]
        public string? LifeCycleStatusCode1 { get; set; }

        [Column("bank_account_type_code_text")]
        public string? BankAccountTypeCodeText { get; set; }

        [Column("payment_medium_format_code1_text")]
        public string? PaymentMediumFormatCode1Text { get; set; }

        [Column("bank_directory_entry_bank_internal_id")]
        public string? BankDirectoryEntryBankInternalId { get; set; }

        [Column("language_code")]
        public string? LanguageCode { get; set; }

        [Column("end_date")]
        public string? EndDate { get; set; }

        [Column("indicator")]
        public string? Indicator { get; set; }

        [Column("company_house_bank_id")]
        public string? CompanyHouseBankId { get; set; }

        [Column("bank_internal_id")]
        public string? BankInternalId { get; set; }

        [Column("creation_date_time")]
        public string? CreationDateTime { get; set; }

        [Column("bank_account_type_code")]
        public string? BankAccountTypeCode { get; set; }

        [Column("house_bank_uuid")]
        public string? HouseBankUuid { get; set; }

        [Column("life_cycle_status_code1_text")]
        public string? LifeCycleStatusCode1Text { get; set; }

        [Column("last_change_date_time")]
        public string? LastChangeDateTime { get; set; }

        [Column("company")]
        public string? Company { get; set; }
    }
}

