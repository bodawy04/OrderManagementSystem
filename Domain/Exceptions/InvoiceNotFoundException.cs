namespace Domain.Exceptions;
public sealed class InvoiceNotFoundException(int id)
    : NotFoundException($"Invoice with id: {id} not found.");