namespace DataAccessLayer.Models
{
    internal class BaseEntity //include the common properties [parent]
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; } //user id
        public DateTime? CreatedOn { get; set; }//the datetime of creating the record
        public int ModifiedBy { get; set; } //user id
        public DateTime ModifiedOn { get; set; }//the datetime of modifing the record
        public bool IsDeleted { get; set; }

    }
}
