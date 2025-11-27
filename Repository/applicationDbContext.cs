using Microsoft.EntityFrameworkCore;
using Repository.Entidades.db;
using Repository.Entidades.db_Externa;


namespace Repository
{
    public class applicationDbContext : DbContext
    {
        public applicationDbContext (DbContextOptions<applicationDbContext> options) : base(options)
        {
        }

        //Configuracion
        public DbSet<Access> Access { get; set; }
        public DbSet<ODataLink> ODataLink { get; set; }
        public DbSet<Entidades.db_Externa.Task> Task { get; set; }
        //Entidades 
        public DbSet<SAP_Maestro_Purchase_Orders> SAP_Maestro_Purchase_Orders { get; set; }
        public DbSet<SAPMaestroPrestamos> SAP_Maestro_Prestamos { get; set; }
        public DbSet<Maestro_Lineas_Credito> Maestro_Lineas_Credito { get; set; }
        public DbSet<Maestro_Cuota_Tipos> Maestro_Cuota_Tipos { get; set; }
        public DbSet<SAP_Maestro_Bancos> SAP_Maestro_Bancos { get; set; }
        public DbSet<SAP_Maestro_Historial_Tasas> SAP_Maestro_Historial_Tasas { get; set; }
        public DbSet<Condiciones> Condiciones { get; set; }
        public DbSet<Maestro_Amortizaciones> Maestro_Amortizaciones { get; set; }
        public DbSet<sap_maestro_cuentas_bancarias> sap_maestro_cuentas_bancarias { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SAPMaestroPrestamos>()
                .HasOne(p => p.Bank)
                .WithMany()
                .HasForeignKey(p => p.bank_id)
                .IsRequired(false);

            modelBuilder.Entity<SAPMaestroPrestamos>()
                .HasOne(p => p.CreditLine)
                .WithMany()
                .HasForeignKey(p => p.creditline_id)
                 .IsRequired(false);

            modelBuilder.Entity<SAPMaestroPrestamos>()
                .HasOne(p => p.CuotaTipo)
                .WithMany()
                .HasForeignKey(p => p.cuotatipo_id)
                .IsRequired(false);

            modelBuilder.Entity<SAPMaestroPrestamos>()
                .HasOne(p => p.condiciones)
                .WithMany()
                .HasForeignKey(p => p.condicion_id)
                .IsRequired(false);

            modelBuilder.Entity<ODataLink>().HasData(
                new ODataLink {id = 1 ,description = "Get Supplier Banck Account",link = "https://my431112.businessbydesign.cloud.sap/sap/byd/odata/ana_businessanalytics_analytics.svc/RPBUPSPP_Q0001QueryResults?$select=CCREATION_DT,CBANK_NAT_CODE,CSTATUS,TSTATUS,CBANK_NAME,CBANK_ACCOUNT_ID,CBP_UUID,TBP_UUID&$top=999999&$format=json&sap-language=ES",body = null ,active = true },
                new ODataLink {id = 2 ,description = "Get Bank Account", link = "https://my427722.businessbydesign.cloud.sap/sap/byd/odata/cust/v1/zcuentasbancarias/ZCuentasBancariasRootCollection?select=BankAccountID,Descripcion&$filter=(IDCompany eq '1000000')and(BankAccountID eq '200009748748' or BankAccountID  eq '112010166696' or BankAccountID  eq '20111013429' or BankAccountID  eq '20111014336' or BankAccountID  eq '200009748748' or BankAccountID  eq '20111013429' or BankAccountID  eq '20111013429')&$top=999999&$format=json&sap-language=ES", body = null ,active = true }
            );
        }
    }
}
