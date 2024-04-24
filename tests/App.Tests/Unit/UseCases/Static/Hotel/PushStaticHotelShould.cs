namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Static.Hotel;

[TestFixture]
public class PushStaticHotelShould {
    private IStaticSynchronizerApiClient staticSynchronizerApiClient;
    private PushStaticHotel pushStaticHotel;

    [SetUp]
    public void SetUp() {
        staticSynchronizerApiClient = Substitute.For<IStaticSynchronizerApiClient>();
        pushStaticHotel = new PushStaticHotel();
    }

    [Test]
    public async Task push_static_hotel() {
        //Given
        var givenEstHotel = EstHotelBuilder.AnEstHotelBuilder().Build();

        //When
        await pushStaticHotel.Execute(givenEstHotel);

        //Then
        var expectedHotel = new Infrastructure.Dtos.BookingCenter.Static.Hotel {
            Code = givenEstHotel.CodigoInterno.ToString(),
            Name = givenEstHotel.NombreHotel,
            OpeningDate = DateTime.MinValue,
            ClosingDate = DateTime.MinValue,
            Category = givenEstHotel.CodigoCategoria,
            CodeType = givenEstHotel.NombreMarcaComercial,
            Type = givenEstHotel.CodigoTipoHotel,
            Director = givenEstHotel.Director,
            NumberOfRooms = givenEstHotel.NumeroHabitaciones,
            Floors = givenEstHotel.NumeroPlantas,
            BuildYear = givenEstHotel.AnioConstruccion,
            Country = givenEstHotel.EsPais,
            CountryCode = givenEstHotel.CodigoPaisIso,
            StateProvince = givenEstHotel.NombreProvincia,
            StateProvinceCode = givenEstHotel.CodigoProvinciaIso,
            City = givenEstHotel.NombreLocalidad,
            CityCode = givenEstHotel.CodigoLocalidad,
            StreetAddress = givenEstHotel.Domicilio,
            PostalCode = givenEstHotel.CodigoPostal,
            Latitude = givenEstHotel.GmapsLatitud,
            Longitude = givenEstHotel.GmapsLongitud,
            Phone = givenEstHotel.Telefono,
            Fax = givenEstHotel.Fax,
            ReferencePerson = "",
            Email = givenEstHotel.Email,
            Web = givenEstHotel.Web,
            ChildMinAge = givenEstHotel.EdadMinNino,
            ChildMaxAge = givenEstHotel.EdadMaxNino,
            TeenMinAge = givenEstHotel.EdadMaxNino + 0.01m,
            TeenMaxAge = 17.99m,
            InfantMinAge = givenEstHotel.EdadMinBebe,
            InfantMaxAge = givenEstHotel.EdadMaxBebe,
            Languages = [],
            Descriptions = [
                new() {
                    ShortDescription = givenEstHotel.EsEntradilla,
                    LargeDescription = givenEstHotel.EsDescripcion,
                    LocationDescription = givenEstHotel.EsSituacion,
                    LanguageIsoCode = "es-ES"
                },
                new() {
                    ShortDescription = givenEstHotel.EnEntradilla,
                    LargeDescription = givenEstHotel.EnDescripcion,
                    LocationDescription = givenEstHotel.EnSituacion,
                    LanguageIsoCode = "en-GB"
                },
                new() {
                    ShortDescription = givenEstHotel.FrEntradilla,
                    LargeDescription = givenEstHotel.FrDescripcion,
                    LocationDescription = givenEstHotel.FrSituacion,
                    LanguageIsoCode = "fr-FR"
                },
                new() {
                    ShortDescription = givenEstHotel.DeEntradilla,
                    LargeDescription = givenEstHotel.DeDescripcion,
                    LocationDescription = givenEstHotel.DeSituacion,
                    LanguageIsoCode = "de-DE"
                },
                new() {
                    ShortDescription = givenEstHotel.PtEntradilla,
                    LargeDescription = givenEstHotel.PtDescripcion,
                    LocationDescription = givenEstHotel.PtSituacion,
                    LanguageIsoCode = "pt-PT"
                }
            ],
            Images = givenEstHotel.Imagenes.Select(imagen => new Image {
                Order = imagen.Prioridad,
                Url = imagen.Url,
                Translations = [
                    new() {
                        Title = imagen.EsTitulo,
                        Description = imagen.EsDescripcion,
                        LanguageIsoCode = "es-ES"
                    },
                    new() {
                        Title = imagen.EnTitulo,
                        Description = imagen.EnDescripcion,
                        LanguageIsoCode = "en-GB"
                    },
                    new() {
                        Title = imagen.FrTitulo,
                        Description = imagen.FrDescripcion,
                        LanguageIsoCode = "fr-FR"
                    },
                    new() {
                        Title = imagen.DeTitulo,
                        Description = imagen.DeDescripcion,
                        LanguageIsoCode = "de-DE"
                    },
                    new() {
                        Title = imagen.PtTitulo,
                        Description = imagen.PtDescripcion,
                        LanguageIsoCode = "pt-PT"
                    }
                    ]
            }).ToList(),
            Rooms = givenEstHotel.Habitaciones.Select(habitacion => new Infrastructure.Dtos.BookingCenter.Static.Room {
                Code = habitacion.CodigoTipoHabitacion,
                Quantity = habitacion.NumeroHabitaciones,
                Surface = habitacion.SuperficieAprox,
                MinWeight = habitacion.PesoMinimo,
                MaxWeight = habitacion.PesoMaximo,
                MinInfants = habitacion.MinBebes,
                MaxInfants = habitacion.MaxBebes,
                MinChildren = habitacion.MinNinos,
                MaxChildren = habitacion.MaxNinos,
                MinTeens = null,
                MaxTeens = null,
                MinAdults = habitacion.MinAdultos,
                MaxAdults = habitacion.MaxAdultos,
                Equipments = [],
                Beds = habitacion.Camas.Select(cama => new Bed {
                    Width = cama.AnchoCm,
                    Length = cama.AltoCm,
                    Translations = [
                        new() {
                            Name = cama.EsNombre,
                            LanguageIsoCode = "es-ES"
                        },
                        new() {
                            Name = cama.EnNombre,
                            LanguageIsoCode = "en-GB"
                        },
                        new() {
                            Name = cama.FrNombre,
                            LanguageIsoCode = "fr-FR"
                        },
                        new() {
                            Name = cama.DeNombre,
                            LanguageIsoCode = "de-DE"
                        },
                        new() {
                            Name = cama.PtNombre,
                            LanguageIsoCode = "pt-PT"
                        }
                        ]
                }).ToList(),
            }).ToList(),
            SwimmingPools = givenEstHotel.Piscinas.Select(piscina => new SwimmingPool {
                Code = piscina.Id.ToString(),
                NumberOfPools = piscina.Cantidad,
                Capacity = piscina.Aforo,
                Surface = piscina.Superficie,
                Translations = [
                    new() {
                        Name = piscina.EsPiscina,
                        LanguageIsoCode = "es-ES"
                    },
                    new() {
                        Name = piscina.EnPiscina,
                        LanguageIsoCode = "en-GB"
                    },
                    new() {
                        Name = piscina.FrPiscina,
                        LanguageIsoCode = "fr-FR"
                    },
                    new() {
                        Name = piscina.DePiscina,
                        LanguageIsoCode = "de-DE"
                    },
                    new() {
                        Name = piscina.PtPiscina,
                        LanguageIsoCode = "pt-PT"
                    }
                    ],
                Images = piscina.Imagenes.Select(imagen => new Image { 
                    Order = imagen.Prioridad,
                    Url = imagen.Url,
                    Translations = [
                        new() {
                            Title = imagen.EsTitulo,
                            Description = imagen.EsDescripcion,
                            LanguageIsoCode = "es-ES"
                        },
                        new() {
                            Title = imagen.EnTitulo,
                            Description = imagen.EnDescripcion,
                            LanguageIsoCode = "en-GB"
                        },
                        new() {
                            Title = imagen.FrTitulo,
                            Description = imagen.FrDescripcion,
                            LanguageIsoCode = "fr-FR"
                        },
                        new() {
                            Title = imagen.DeTitulo,
                            Description = imagen.DeDescripcion,
                            LanguageIsoCode = "de-DE"
                        },
                        new() {
                            Title = imagen.PtTitulo,
                            Description = imagen.PtDescripcion,
                            LanguageIsoCode = "pt-PT"
                        }
                        ]
                }).ToList()
            }).ToList(),
            Salons = givenEstHotel.Salones.Select(salon => new Salon { 
                Code = salon.Id.ToString(),
                Name = salon.EsNombre,
                Surface = salon.Superficie,
                Width = salon.Ancho,
                Length = salon.Largo,
                Height = salon.Altura,
                FeastCapacity = salon.AforoBanquete,
                CocktailCapacity = salon.AforoCocktail,
                ImperialCapacity = salon.AforoImperial,
                UCapacity = salon.AforoU,
                ClassroomCapacity = salon.AforoAula,
                Translations = [
                    new() {
                        Name = salon.EsDescripcion,
                        LanguageIsoCode = "es-ES"
                    },
                    new() {
                        Name = salon.EnDescripcion,
                        LanguageIsoCode = "en-GB"
                    },
                    new() {
                        Name = salon.FrDescripcion,
                        LanguageIsoCode = "fr-FR"
                    },
                    new() {
                        Name = salon.DeDescripcion,
                        LanguageIsoCode = "de-DE"
                    },
                    new() {
                        Name = salon.PtDescripcion,
                        LanguageIsoCode = "pt-PT"
                    }
                    ],
            }).ToList(),
            Services = givenEstHotel.IdServicios.Select(i => i.ToString()).ToList(),
            Taxes = givenEstHotel.IdReszoims,
            HotelChainCode = ""
        };
        await staticSynchronizerApiClient.Received()
            .PushHotel(Arg.Is<Infrastructure.Dtos.BookingCenter.Static.Hotel>(x => IsEquivalent(x, expectedHotel)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
