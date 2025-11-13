using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entidades.db_Externa
{
    [Table("SAP_Maestro_Purchase_Orders")]
    public class SAP_Maestro_Purchase_Orders
    {
        [Column("company")]
        public string? Company { get; set; }

        [Column("createdate")]
        public DateTime? CreateDate { get; set; }

        [Column("updatedate")]
        public DateTime? UpdateDate { get; set; }

        [Column("contractnumberreference")]
        public string? ContractNumberReference { get; set; }

        [Column("contractdescriptionreference")]
        public string? ContractDescriptionReference { get; set; }

        [Column("ordernumber")]
        public string? OrderNumber { get; set; }

        [Column("blnumber")]
        public string? BlNumber { get; set; }

        [Column("invoicenumberreference")]
        public string? InvoiceNumberReference { get; set; }

        [Column("containernumber")]
        public string? ContainerNumber { get; set; }

        [Column("status_text")]
        public string? StatusText { get; set; }

        [Column("createdbyuser")]
        public string? CreatedByUser { get; set; }

        [Column("suppliercode")]
        public string? SupplierCode { get; set; }

        [Column("suppliername")]
        public string? SupplierName { get; set; }

        [Column("productcode")]
        public string? ProductCode { get; set; }

        [Column("productdescription")]
        public string? ProductDescription { get; set; }

        [Column("productcategory")]
        public string? ProductCategory { get; set; }

        [Column("currency")]
        public string? Currency { get; set; }

        [Column("productnetprice")]
        public double? ProductNetPrice { get; set; }

        [Column("quantityrequested")]
        public double? QuantityRequested { get; set; }

        [Column("quantitydelivered")]
        public double? QuantityDelivered { get; set; }

        [Column("balance")]
        public double? Balance { get; set; }

        [Column("delivereddate")]
        public DateTime? DeliveredDate { get; set; }

        [Column("etd")]
        public DateTime? ETD { get; set; }

        [Column("etainitial")]
        public DateTime? ETAInitial { get; set; }

        [Column("etaprojected")]
        public DateTime? ETAProjected { get; set; }

        [Column("etashipping")]
        public DateTime? ETAShipping { get; set; }

        [Column("masterblnumber")]
        public string? MasterBLNumber { get; set; }

        [Column("orderstatus")]
        public string? OrderStatus { get; set; }

        [Column("location_text")]
        public string? LocationText { get; set; }

        [Column("id")]
        public int Id { get; set; }

        [Column("shippingcode")]
        public string? ShippingCode { get; set; }

        [Column("JsonResponse")]
        public string? JsonResponse { get; set; }

        [Column("UpdateDateSearates")]
        public DateTime? UpdateDateSearates { get; set; }

        [Column("SearatesStatus")]
        public string? SearatesStatus { get; set; }
    }
}
