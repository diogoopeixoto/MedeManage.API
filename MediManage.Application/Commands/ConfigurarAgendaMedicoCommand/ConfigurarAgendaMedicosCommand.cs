using MediatR;
using MediManage.Application.ViewModels;

public class ConfigurarAgendaMedicosCommand : IRequest<Unit>
{
    public int MedicoId { get; set; }
    public List<DiaDeAtendimentoDto> DiasDeAtendimento { get; set; }


    public ConfigurarAgendaMedicosCommand(int medicoId, List<DiaDeAtendimentoDto> diasDeAtendimento)
    {
        MedicoId = medicoId;
        DiasDeAtendimento = diasDeAtendimento;
    }
}

