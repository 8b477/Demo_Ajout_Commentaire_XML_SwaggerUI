public static void ConfigureSwagger(this IServiceCollection services)
{
    services.AddSwaggerGen(c =>
    {

    //Partie doc au sujet de l'api
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "API DokiHouse",
            Version = "v1",
            Description = "Cette API est fait par un noob attention !",
        });


    //Partie affichage commentaire ///summary
        var xmlhelp = "API_DokiHouse.xml"; // => t'ajoute le nom du projet de ton API.xml
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlhelp));


    //Partie ajout la possibilité de test un token directement dans SwaggerUI
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });
}