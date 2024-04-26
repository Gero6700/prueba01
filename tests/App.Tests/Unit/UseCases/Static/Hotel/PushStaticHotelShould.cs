using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Helpers;

namespace Senator.As400.Cloud.Sync.App.Tests.Unit.UseCases.Static.Hotel;

[TestFixture]
public class PushStaticHotelShould {
    private IStaticSynchronizerApiClient staticSynchronizerApiClient;
    private PushStaticHotel pushStaticHotel;

    [SetUp]
    public void SetUp() {
        staticSynchronizerApiClient = Substitute.For<IStaticSynchronizerApiClient>();
        pushStaticHotel = new PushStaticHotel(staticSynchronizerApiClient);
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
            OpeningDate = givenEstHotel.CerradoHasta?.AddDays(1),
            ClosingDate = givenEstHotel.CerradoDesde,
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
                    LanguageIsoCode = Language.Es.GetIsoCode()
                },
                new() {
                    ShortDescription = givenEstHotel.EnEntradilla,
                    LargeDescription = givenEstHotel.EnDescripcion,
                    LocationDescription = givenEstHotel.EnSituacion,
                    LanguageIsoCode = Language.En.GetIsoCode()
                },
                new() {
                    ShortDescription = givenEstHotel.FrEntradilla,
                    LargeDescription = givenEstHotel.FrDescripcion,
                    LocationDescription = givenEstHotel.FrSituacion,
                    LanguageIsoCode = Language.Fr.GetIsoCode()
                },
                new() {
                    ShortDescription = givenEstHotel.DeEntradilla,
                    LargeDescription = givenEstHotel.DeDescripcion,
                    LocationDescription = givenEstHotel.DeSituacion,
                    LanguageIsoCode = Language.De.GetIsoCode()
                },
                new() {
                    ShortDescription = givenEstHotel.PtEntradilla,
                    LargeDescription = givenEstHotel.PtDescripcion,
                    LocationDescription = givenEstHotel.PtSituacion,
                    LanguageIsoCode = Language.Pt.GetIsoCode()
                }
            ],
            Images = givenEstHotel.Imagenes.Select(imagen => new Image {
                Order = imagen.Prioridad,
                Url = imagen.Url,
                Translations = [
                    new() {
                        Title = imagen.EsTitulo,
                        Description = imagen.EsDescripcion,
                        LanguageIsoCode = Language.Es.GetIsoCode()
                    },
                    new() {
                        Title = imagen.EnTitulo,
                        Description = imagen.EnDescripcion,
                        LanguageIsoCode = Language.En.GetIsoCode()
                    },
                    new() {
                        Title = imagen.FrTitulo,
                        Description = imagen.FrDescripcion,
                        LanguageIsoCode = Language.Fr.GetIsoCode()
                    },
                    new() {
                        Title = imagen.DeTitulo,
                        Description = imagen.DeDescripcion,
                        LanguageIsoCode = Language.De.GetIsoCode()
                    },
                    new() {
                        Title = imagen.PtTitulo,
                        Description = imagen.PtDescripcion,
                        LanguageIsoCode = Language.Pt.GetIsoCode()
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
                            LanguageIsoCode = Language.Es.GetIsoCode()
                        },
                        new() {
                            Name = cama.EnNombre,
                            LanguageIsoCode = Language.En.GetIsoCode()
                        },
                        new() {
                            Name = cama.FrNombre,
                            LanguageIsoCode = Language.Fr.GetIsoCode()
                        },
                        new() {
                            Name = cama.DeNombre,
                            LanguageIsoCode = Language.De.GetIsoCode()
                        },
                        new() {
                            Name = cama.PtNombre,
                            LanguageIsoCode = Language.Pt.GetIsoCode()
                        }
                        ]
                }).ToList(),
                Images = habitacion.Imagenes.Select(imagen => new Image {
                    Order = imagen.Prioridad,
                    Url = imagen.Url,
                    Translations = [
                        new() {
                            Title = imagen.EsTitulo,
                            Description = imagen.EsDescripcion,
                            LanguageIsoCode = Language.Es.GetIsoCode()
                        },
                        new() {
                            Title = imagen.EnTitulo,
                            Description = imagen.EnDescripcion,
                            LanguageIsoCode = Language.En.GetIsoCode()
                        },
                        new() {
                            Title = imagen.FrTitulo,
                            Description = imagen.FrDescripcion,
                            LanguageIsoCode = Language.Fr.GetIsoCode()
                        },
                        new() {
                            Title = imagen.DeTitulo,
                            Description = imagen.DeDescripcion,
                            LanguageIsoCode = Language.De.GetIsoCode()
                        },
                        new() {
                            Title = imagen.PtTitulo,
                            Description = imagen.PtDescripcion,
                            LanguageIsoCode = Language.Pt.GetIsoCode()
                        }
                        ]
                }).ToList(),
                Translations = [
                    new() {
                        Name = habitacion.EsNombreVerano,
                        Description = habitacion.EsDescripcion,
                        ShortDescription = habitacion.EsEntradilla,
                        LanguageIsoCode = Language.Es.GetIsoCode()
                    },
                    new() {
                        Name = habitacion.EnNombreVerano,
                        Description = habitacion.EnDescripcion,
                        ShortDescription = habitacion.EnEntradilla,
                        LanguageIsoCode = Language.En.GetIsoCode()
                    },
                    new() {
                        Name = habitacion.FrNombreVerano,
                        Description = habitacion.FrDescripcion,
                        ShortDescription = habitacion.FrEntradilla,
                        LanguageIsoCode = Language.Fr.GetIsoCode()
                    },
                    new() {
                        Name = habitacion.DeNombreVerano,
                        Description = habitacion.DeDescripcion,
                        ShortDescription = habitacion.DeEntradilla,
                        LanguageIsoCode = Language.De.GetIsoCode()
                    },
                    new() {
                        Name = habitacion.PtNombreVerano,
                        Description = habitacion.PtDescripcion,
                        ShortDescription = habitacion.PtEntradilla,
                        LanguageIsoCode = Language.Pt.GetIsoCode()
                    }
                    ]
            }).ToList(),
            SwimmingPools = givenEstHotel.Piscinas.Select(piscina => new SwimmingPool {
                Code = piscina.Id.ToString(),
                NumberOfPools = piscina.Cantidad,
                Capacity = piscina.Aforo,
                Surface = piscina.Superficie,
                Translations = [
                    new() {
                        Name = piscina.EsPiscina,
                        LanguageIsoCode = Language.Es.GetIsoCode()
                    },
                    new() {
                        Name = piscina.EnPiscina,
                        LanguageIsoCode = Language.En.GetIsoCode()
                    },
                    new() {
                        Name = piscina.FrPiscina,
                        LanguageIsoCode = Language.Fr.GetIsoCode()
                    },
                    new() {
                        Name = piscina.DePiscina,
                        LanguageIsoCode = Language.De.GetIsoCode()
                    },
                    new() {
                        Name = piscina.PtPiscina,
                        LanguageIsoCode = Language.Pt.GetIsoCode()
                    }
                    ],
                Images = piscina.Imagenes.Select(imagen => new Image { 
                    Order = imagen.Prioridad,
                    Url = imagen.Url,
                    Translations = [
                        new() {
                            Title = imagen.EsTitulo,
                            Description = imagen.EsDescripcion,
                            LanguageIsoCode = Language.Es.GetIsoCode()
                        },
                        new() {
                            Title = imagen.EnTitulo,
                            Description = imagen.EnDescripcion,
                            LanguageIsoCode = Language.En.GetIsoCode()
                        },
                        new() {
                            Title = imagen.FrTitulo,
                            Description = imagen.FrDescripcion,
                            LanguageIsoCode = Language.Fr.GetIsoCode()
                        },
                        new() {
                            Title = imagen.DeTitulo,
                            Description = imagen.DeDescripcion,
                            LanguageIsoCode = Language.De.GetIsoCode()
                        },
                        new() {
                            Title = imagen.PtTitulo,
                            Description = imagen.PtDescripcion,
                            LanguageIsoCode = Language.Pt.GetIsoCode()
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
                        LanguageIsoCode = Language.Es.GetIsoCode()
                    },
                    new() {
                        Name = salon.EnDescripcion,
                        LanguageIsoCode = Language.En.GetIsoCode()
                    },
                    new() {
                        Name = salon.FrDescripcion,
                        LanguageIsoCode = Language.Fr.GetIsoCode()
                    },
                    new() {
                        Name = salon.DeDescripcion,
                        LanguageIsoCode = Language.De.GetIsoCode()
                    },
                    new() {
                        Name = salon.PtDescripcion,
                        LanguageIsoCode = Language.Pt.GetIsoCode()
                    }
                    ],
                Images = salon.Imagenes.Select(imagen => new Image {
                    Order = imagen.Prioridad,
                    Url = imagen.Url,
                    Translations = [
                        new() {
                            Title = imagen.EsTitulo,
                            Description = imagen.EsDescripcion,
                            LanguageIsoCode = Language.Es.GetIsoCode()
                        },
                        new() {
                            Title = imagen.EnTitulo,
                            Description = imagen.EnDescripcion,
                            LanguageIsoCode = Language.En.GetIsoCode()
                        },
                        new() {
                            Title = imagen.FrTitulo,
                            Description = imagen.FrDescripcion,
                            LanguageIsoCode = Language.Fr.GetIsoCode()
                        },
                        new() {
                            Title = imagen.DeTitulo,
                            Description = imagen.DeDescripcion,
                            LanguageIsoCode = Language.De.GetIsoCode()
                        },
                        new() {
                            Title = imagen.PtTitulo,
                            Description = imagen.PtDescripcion,
                            LanguageIsoCode = Language.Pt.GetIsoCode()
                        }
                        ]
                }).ToList()
            }).ToList(),
            Services = givenEstHotel.IdServicios.Select(i => i.ToString()).ToList(),
            Taxes = givenEstHotel.IdReszoims
        };
        await staticSynchronizerApiClient.Received()
            .PushHotel(Arg.Is<Infrastructure.Dtos.BookingCenter.Static.Hotel>(x => IsEquivalent(x, expectedHotel)));
    }

    private bool IsEquivalent(object source, object expected) {
        source.Should().BeEquivalentTo(expected);
        return true;
    }
}
