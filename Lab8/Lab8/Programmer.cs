
namespace lab08
{
    public delegate void RenameEventHandler(string name);
    public delegate void NewPropertyEventHandler(string name);
    public class Programmer {

        private string name;
        public Programmer(string n)
        {
            name = n;
        }
        public RenameEventHandler Rename;
        public NewPropertyEventHandler NewProperty;

        public void CommandCProp(string n)
        {
            NewProperty.Invoke(n);
            Console.WriteLine("^^ Вызвано событие изменения свойств!   ^^");
        }

        public void CommandRenameOperation(string n)
        {
            Rename.Invoke(n);
            Console.WriteLine("^^   Вызвано событие Rename!   ^^");
        }

    }

}