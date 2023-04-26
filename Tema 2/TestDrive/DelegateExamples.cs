namespace TestDrive
{

    public class DelegateExamples
    {
        public delegate string MyMethodDelegate(int prop);

        public string MyMethod(int prop)
        {
            return $"{prop} e numarul meu favorit!";
        }

        public string MySecondMethod(int prop)
        {
            return $"Urat este numarul {prop}";
        }

    }
}
