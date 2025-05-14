namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public interface ICreateStaticHotelTax {
    Task<HttpResponseMessage> Execute(ReszoimH reszoimH);
}
