namespace Lab_03
{
    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}
