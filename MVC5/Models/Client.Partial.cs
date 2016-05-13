namespace MVC5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ClientMetaData))]
    public partial class Client : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.CreditRating.HasValue && (int)this.CreditRating % 2 != 0)
            {
                yield return new ValidationResult("必須為偶數!!" , new[] { "CreditRating" });
            }
            if(!String.IsNullOrEmpty(this.FirstName) && this.FirstName.Length < 5)
            {
                yield return new ValidationResult("名稱長度應大於5!!", new[] { "FirstName" });

            }
        }
    }
    
    public partial class ClientMetaData
    {
        [Required]
        public int ClientId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string FirstName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string MiddleName { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string LastName { get; set; }
        
        [StringLength(1, ErrorMessage="欄位長度不得大於 1 個字元")]
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        //[Odd(ErrorMessage = "欄位應輸入偶數")]//也可oddattribute
        [Required]
        public Nullable<double> CreditRating { get; set; }
        
        [StringLength(7, ErrorMessage="欄位長度不得大於 7 個字元")]
        public string XCode { get; set; }
        public Nullable<int> OccupationId { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string TelephoneNumber { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string Street1 { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string Street2 { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string City { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        public string ZipCode { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
        public string Notes { get; set; }
    
        public virtual Occupation Occupation { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }


}
