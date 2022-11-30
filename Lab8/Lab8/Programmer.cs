
namespace lab08
{
    public delegate void RenameEventHandler(string name);
    public delegate void NewPropertyEventHandler(string name);
    public delegate void VersionEventHandler(double ver);
    public class Programmer {

        private string name;
        public Programmer(string n)
        {
            name = n;
        }
        public event RenameEventHandler Rename;
        public event VersionEventHandler Version;
        public event NewPropertyEventHandler NewProperty;

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
        public void CommandSetVersion(double v)
        {
            Version.Invoke(v);
            Console.WriteLine("^^   Вызвано событие изменения версии!   ^^");
        }

    }

}