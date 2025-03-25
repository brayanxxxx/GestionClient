# Proyecto de Gestión de Clientes

## 1. Introducción

Este proyecto es una aplicación de escritorio desarrollada con Windows Forms para la administración de clientes individuales y corporativos. El sistema permite la creación, gestión y visualización de información de clientes, siguiendo principios de diseño que favorecen la escalabilidad y el mantenimiento.

Este documento proporciona una descripción general de la estructura del proyecto y los patrones de diseño implementados.

## 2. Estructura del Proyecto

El proyecto se organiza en las siguientes clases principales:

### 2.1. Cliente Base

* **Cliente:** Clase abstracta que define las propiedades y comportamientos comunes a todos los tipos de clientes (individual y corporativo).
* **ClienteIndividual:** Clase que hereda de `Cliente` y añade funcionalidades específicas para clientes individuales, incluyendo la restricción en la cantidad de cuentas activas.
* **ClienteCorporativo:** Clase que hereda de `Cliente` y gestiona funcionalidades específicas para clientes corporativos, como el acceso a una línea de crédito.

### 2.2. Gestión de Clientes

* **GestorClientes:** Clase que implementa el patrón Singleton para mantener una única instancia y gestionar una lista de todos los clientes en el sistema.

### 2.3. Creación de Clientes

* **ClienteFactory:** Clase que implementa el patrón Factory para la creación de instancias de `ClienteIndividual` y `ClienteCorporativo` basándose en un tipo especificado.

### 2.4. Interfaz Gráfica (Windows Forms)

* **FormularioNuevoClienteBase:** Clase base abstracta para los formularios utilizados en la creación de nuevos clientes. Define los controles y la lógica compartida entre los diferentes tipos de formularios de creación.
* **FormularioNuevoClienteIndividual:** Clase que hereda de `FormularioNuevoClienteBase` y proporciona la interfaz de usuario específica para la creación de clientes individuales, incluyendo controles para la cantidad de cuentas.
* **FormularioNuevoClienteCorporativo:** Clase que hereda de `FormularioNuevoClienteBase` y proporciona la interfaz de usuario específica para la creación de clientes corporativos, incluyendo controles para la línea de crédito (si aplica).

## 3. Patrones de Diseño Implementados

El proyecto utiliza los siguientes patrones de diseño para promover la flexibilidad, extensibilidad y mantenibilidad del código:

* **Singleton:** Implementado en la clase `GestorClientes` para asegurar que exista una única instancia de la clase responsable de gestionar la lista de clientes.
* **Factory:** Implementado en la clase `ClienteFactory` para abstraer el proceso de creación de instancias de las clases `ClienteIndividual` y `ClienteCorporativo`. Esto permite crear objetos cliente sin conocer la clase concreta que se está instanciando.
* **Herencia:** Utilizada extensivamente en la jerarquía de clases `Cliente` (`ClienteIndividual`, `ClienteCorporativo`) y en la jerarquía de formularios (`FormularioNuevoClienteBase`, `FormularioNuevoClienteIndividual`, `FormularioNuevoClienteCorporativo`) para reutilizar código y definir comportamientos específicos en las subclases.

## 4. Interfaz Gráfica (Windows Forms)

La interfaz gráfica se construye utilizando formularios de Windows Forms. Se emplea la herencia para compartir la lógica y los controles comunes entre los formularios de creación de clientes.

* **FormularioNuevoClienteBase:** Contiene los campos comunes como Nombre, Identificación y Saldo, así como los botones Aceptar y Cancelar.
* **FormularioNuevoClienteIndividual:** Extiende `FormularioNuevoClienteBase` y añade controles específicos para clientes individuales, como la "Cantidad de Cuentas".
* **FormularioNuevoClienteCorporativo:** (Si existe) Extiende `FormularioNuevoClienteBase` y contendría controles específicos para clientes corporativos, como la opción de "Línea de Crédito".

## 5. Consideraciones de Diseño y Escalabilidad

El diseño del sistema se ha realizado teniendo en cuenta los principios SOLID para facilitar el mantenimiento y la escalabilidad:

* **Single Responsibility (S):** Cada clase tiene una única responsabilidad bien definida.
* **Open/Closed (O):** El código está diseñado para ser extensible sin necesidad de modificar las clases existentes.
* **Liskov Substitution (L):** Las subclases (`ClienteIndividual`, `ClienteCorporativo`) pueden ser sustituidas por su clase base (`Cliente`) sin afectar la correcta ejecución del programa.
* **Interface Segregation (I) & Dependency Inversion (D):** Estos principios se consideran para futuras mejoras, como la implementación de interfaces para repositorios de datos o la inyección de dependencias, lo que aumentaría la flexibilidad y la capacidad de prueba del sistema.

## 6. Repositorio de GitHub

El código fuente de este proyecto se encuentra disponible en el siguiente repositorio de GitHub:

[brayanxxxx/GestionClient](https://github.com/brayanxxxx/GestionClient)
