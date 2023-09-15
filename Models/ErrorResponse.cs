﻿namespace CS330Final.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string? FieldName { get; set; }
        public ErrorType DBCode { get; set; }
        public object? Data { get; set; }
    }
    public enum ErrorType
    {
        Nil = 0,
        MissingField,
        InvalidData,
        NullOrEmptyField,
    }
}
