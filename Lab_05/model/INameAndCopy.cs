namespace Lab_05
{
    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}
