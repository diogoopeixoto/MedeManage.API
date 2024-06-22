namespace MediManage.Core.Entities
{
    public class DiaDeAtendimento
    {
        public int Id { get; set; }
        public DateTime Dia { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fim { get; set; }
        public TimeSpan Intervalo { get; set; }

        // Referência ao médico
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
    }
}
