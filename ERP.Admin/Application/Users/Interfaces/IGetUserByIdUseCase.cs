﻿using Domain.Entities;

namespace Application.Users.Interfaces
{
    public interface IGetUserByIdUseCase
    {
        Task<User> ExecuteAsync(Guid userId);
    }
}