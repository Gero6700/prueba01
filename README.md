# Senator Integrations Synchronizer

El proyecto de Senator Integrations Synchronizer consiste en sincronizar los datos existentes en el AS400 de Playa Senator con las bases de datos de disponibilidad (AvailabilityDatabase) y reserva (BookingDatabase) necesarias para la integración de los distintos clientes de Playa Senator (Sidetours, Opentours, etc.).

<br/>
<br/>

## Índice

- [Comenzando](#comenzando-🚀)
- [Ejecutando las pruebas](#ejecutando-las-pruebas-⚙️)
- [Despliegue](#despliegue-📦)
- [Construido con](#construido-con-🛠️)
- [Contribuyendo](#contribuyendo-🖇️)
- [Wiki](#wiki-📖)
- [Versionado](#versionado-📌)
- [Autores](#autores-✒️)
- [Licencia](#licencia-📄)
- [Expresiones de gratitud](#expresiones-de-gratitud-🎁)


## Comenzando 🚀

_Estas instrucciones te permitirán obtener una copia del proyecto en funcionamiento en tu máquina local para propósitos de desarrollo y pruebas._

Mira **Deployment** para conocer como desplegar el proyecto.

### Pre-requisitos 📋

_Que cosas necesitas para instalar el software y como instalarlas_

```
Da un ejemplo
```

### Instalación 🔧

_Una serie de ejemplos paso a paso que te dice lo que debes ejecutar para tener un entorno de desarrollo ejecutandose_

DOCKER:
docker run -itd --name db2-local --privileged=true -p 50000:50000 -e LICENSE=accept -e DB2INST1_PASSWORD=wBJNz12@OtE0 -e DBNAME=AS400SHR -v C:/Workspace/DB2:/database ibmcom/db2

_Dí cómo será ese paso_

```
Da un ejemplo
```

_Y repite_

```
hasta finalizar
```

_Finaliza con un ejemplo de cómo obtener datos del sistema o como usarlos para una pequeña demo_


## Ejecutando las pruebas ⚙️

_Explica como ejecutar las pruebas automatizadas para este sistema_

### Analice las pruebas end-to-end 🔩

_Explica que verifican estas pruebas y por qué_

```
Da un ejemplo
```

### Y las pruebas de estilo de codificación ⌨️

_Explica que verifican estas pruebas y por qué_

```
Da un ejemplo
```


## Despliegue 📦

_Agrega notas adicionales sobre como hacer deploy_


## Construido con 🛠️

_Menciona las herramientas que utilizaste para crear tu proyecto_

* [.NET 6](http://...) - El framework usado
* [Serilog](https://...) - Manejador de logging
* [Quartz.NET](https://...) - Cron .NET


## Contribuyendo 🖇️

Por favor lee el [CONTRIBUTING.md](./doc/CONTRIBUTING.md) para detalles de nuestro código de conducta, y el proceso para enviarnos pull requests.


## Wiki 📖

Puedes encontrar mucho más de cómo utilizar este proyecto en nuestra [Wiki](https://github.com/playa-senator/beds2b-agencies/wiki)


## Versionado 📌

Usamos [SemVer](http://semver.org/) para el versionado. Para todas las versiones disponibles, mira los [tags en este repositorio](https://github.com/playa-senator/beds2b-agencies/tags).

En el [CHANGELOG.md](./doc/CHANGELOG.md) también podrás ver las distintas versiones así como sus changelogs.


## Autores ✒️

_Menciona a todos aquellos que ayudaron a levantar el proyecto desde sus inicios_

* **Jesús González** - *Trabajo Inicial* - [jgonzalez-shr](https://github.com/jgonzalez-shr)
* **Fulanito Detal** - *Documentación* - [fulanitodetal](#fulanito-de-tal)

También puedes mirar la lista de todos los [contribuyentes](https://github.com/playa-senator/beds2b-agencies/contributors) quíenes han participado en este proyecto. 


## Licencia 📄

Este proyecto está bajo la Licencia (Tu Licencia) - mira el archivo [LICENSE.md](LICENSE.md) para detalles


## Expresiones de Gratitud 🎁

* Comenta a otros sobre este proyecto 📢
* Invita una cerveza 🍺 o un café ☕ a alguien del equipo. 
* Da las gracias públicamente 🤓.
* etc.
