namespace Repository.Entidades.Odatas
{
    public class SupplierBanckAccount
    {
        public int Id { get; set; }
        public string? CBANK_ACCOUNT_ID { get; set; }  // ID de la cuenta bancaria
        public string? CBANK_NAME { get; set; }    // Nombre del banco
        public string CBANK_NAT_CODE { get; set; }   // 
        public string? CBP_UUID { get; set; }  //
        public string? CCREATION_DT { get; set; }  //Fecha de creación
        public  string? CSTATUS { get; set; }    // Estado
        public string? TBP_UUID { get; set; }   // ID del socio comercial
        public string? TSTATUS { get; set; }  // Estado del socio comercial
    }
}
