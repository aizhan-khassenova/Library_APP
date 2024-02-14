namespace Library_APP
{
    //интерфейс определяющий контракты для методов сортировки книг по идентификатору, названию, автору и году публикации
    public interface ISort
    {
        public void SortById();
        public void SortByTitle();
        public void SortByAuthor();
        public void SortByPubYear();
    }
}