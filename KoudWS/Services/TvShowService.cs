using AutoMapper;
using KoudWS.Exceptions;
using KoudWS.Interfaces;
using KoudWS.Models.DTOs;
using KoudWS.Models.Entities;
using KoudWS.Models.ViewModels;

namespace KoudWS.Services
{
    public class TvShowService : ITvShowService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidatorService _validatorService;
        public TvShowService(IMapper mapper, IUnitOfWork unitOfWork, IValidatorService validatorService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validatorService = validatorService;
        }
        public async Task<TvShowDTO?> AddShow(TvShowVM tvShowVM)
        {
            try
            {
                if (await TvShowAlreadyExist(tvShowVM.Name))
                    return null;

                await _unitOfWork.TvShowRepository.InsertAsync(new TvShowEntity()
                {
                    Name_tvshow = tvShowVM.Name,
                    Favorite_tvshow = tvShowVM.Favorite
                });
                await _unitOfWork.CommitAsync();

                TvShowEntity? tvShowEntity = await _unitOfWork.TvShowRepository.GetByName(tvShowVM.Name);
                if (tvShowEntity == null)
                    throw new TvShowNotAdded(tvShowVM.Name);

                return _mapper.Map<TvShowDTO>(tvShowEntity!);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteShow(string name)
        {
            try
            {
                TvShowEntity? tvShowEntity = await _unitOfWork.TvShowRepository.GetByName(name);
                if (tvShowEntity == null)
                    throw new TvShowNotFoundException(name);

                _unitOfWork.TvShowRepository.Delete(tvShowEntity);
                await _unitOfWork.CommitAsync();

                if (await TvShowAlreadyExist(name))
                    return false;

                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TvShowDTO>> GetAll()
        {
            try
            {
                IEnumerable<TvShowEntity>? tvShowEntities = await _unitOfWork.TvShowRepository.GetAllAsync();
                _validatorService.IsNull(tvShowEntities, new InvalidOperationException(), nameof(tvShowEntities));

                List<TvShowDTO> tvShowDTOs = new List<TvShowDTO>();
                foreach (TvShowEntity entity in tvShowEntities!)
                {
                    TvShowDTO tvShowDTO = _mapper.Map<TvShowDTO>(entity);
                    tvShowDTOs.Add(tvShowDTO);
                }

                return tvShowDTOs;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<TvShowDTO?> GetShow(string name)
        {
            try
            {
                TvShowEntity? tvShowEntity = await _unitOfWork.TvShowRepository.GetByName(name);
                if (tvShowEntity == null)
                    return null;

                return _mapper.Map<TvShowDTO>(tvShowEntity!);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<TvShowDTO?> IsFavorite(TvShowVM tvShowVM)
        {
            try
            {
                TvShowEntity? tvShowEntity = await _unitOfWork.TvShowRepository.GetByName(tvShowVM.Name);
                if (tvShowEntity == null)
                    return null;

                tvShowEntity.Favorite_tvshow = tvShowVM.Favorite;

                _unitOfWork.TvShowRepository.Update(tvShowEntity);
                await _unitOfWork.CommitAsync();

                TvShowDTO tvShowDTO = _mapper.Map<TvShowDTO>(await _unitOfWork.TvShowRepository.GetByName(tvShowVM.Name));

                return tvShowDTO!;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private async Task<bool> TvShowAlreadyExist(string name)
        {
            try
            {
                return await _unitOfWork.TvShowRepository.GetByName(name) != null;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}