namespace Domain.Exceptions;

public sealed class OrderNotFoundException(int id) 
    : NotFoundException($"Order with id: {id} not found");
