namespace Lab_02
{
    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}
