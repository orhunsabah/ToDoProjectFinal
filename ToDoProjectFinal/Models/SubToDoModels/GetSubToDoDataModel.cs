namespace ToDoProjectFinal.Models.SubToDoModels
{
    public class GetSubToDoDataModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public bool IsDone { get; set; }

        public int EffectPercentage { get; set; }

        public int ToDoId { get; set; }


    }
}
