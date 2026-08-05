using BTDS.DTOs;

namespace BTDS.Interface
{
    public interface IGateService
    {
        Task<List<GateResponseDto>> GetAllGates();

        Task<GateResponseDto> GetGate(int gateId);

        Task<GateResponseDto> AddGate(GateCreateDto dto);

        Task<GateResponseDto> UpdateGate(GateUpdateDto dto);

        Task<GateResponseDto> DeleteGate(int gateId);
    }
}
