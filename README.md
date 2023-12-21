# Demo ajout des commentaires XML dans SwaggerUI
<br>
<br>

Petit tuto pour montré comment activer les commentaires ///summary et les afficher dans le visuel de Swagger

EN + :

- Ajout de doc comme la version de l'api, un résumé, un titre.
- Mise en place la possibilité de s'authentifier via un token directement dans swagger.
- Supprimer les avertissements.

<br>

------------------------  
<br>


# (1). PREMIERE ETAPE

![Step one](https://github.com/8b477/Demo_Ajout_Commentaire_XML_SwaggerUI/blob/main/Images/step1.png)


# (2). SECONDE ETAPE

![Step two](https://github.com/8b477/Demo_Ajout_Commentaire_XML_SwaggerUI/blob/main/Images/step2.png)



# (3). MISE EN PLACE DU SERVICE
```c#
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
```


# (4). APPELLE DANS PROGRAM.CS
```c#
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//****************** SWAGGER CONFIG *********************
SwaggerService.ConfigureSwagger(builder.Services);
//*******************************************************



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
```
# (5). SUPPRIME LES AVERTISSEMENTS  
- Clic droit sur ton projet ou est ton API
- Propriétés
- Dans la barre de recherche en haut à gauche tape 'aver'
- Aller dans supprimer les avertissements
- Ajouter le code CS1591
- Attention séparer les différents code par un point virgule => ;

![Step five](https://github.com/8b477/Demo_Ajout_Commentaire_XML_SwaggerUI/blob/main/Images/step5.png)


