namespace Lab_04
{
    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}
