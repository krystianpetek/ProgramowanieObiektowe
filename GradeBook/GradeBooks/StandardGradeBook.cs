namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, bool boolean) : base(name, boolean)
        {
            Type = Enums.GradeBookType.Standard;
        }
    }
}