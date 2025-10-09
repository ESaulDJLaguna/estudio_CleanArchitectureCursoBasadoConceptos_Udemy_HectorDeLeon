# estudio_CleanArchitectureCursoBasadoConceptos_Udemy_HectorDeLeon

Proyecto(s) que se desarrollan en el curso 'Clean Architecture en C# .NET, un curso basado en conceptos' impartido por Héctor de León en Udemy

## Sección 4: Paradigma Funcional

### 28. Paradigma funcional

Es un paradigma que se basa en funciones. Esto se toma de algo llamado "Cálculo Lambda", que prácticamente es trabajar con funciones y estas funciones tienen que ser funciones puras. Una **Función pura** es una función la cual siempre que se le manda un valor de entrada va a regresar el mismo valor de salida y no tiene efectos colaterales, es decir, no modifica el entorno fuera de ello.

- Función de orden superior: son aquellas que pueden recibir como parámetro funciones de primera clase
- Función de primera clase: cualquier función que pueda ser tratada como una variable

Este paradigma nos permite un control de las responsabilidades únicas por medio de funciones. También nos permite inmutabilidad, es decir, como no se tiene funciones que tengan efectos colaterales fueras de ella, todo lo que se manda se clona internamente y no se altera lo que está fuera de ella, esto permite que tengamos un buen control para sistemas que son concurrentes, sistemas que manejan mucha información y sobre todo para inteligencia artificial.

### 29. Función Pura

Una función pura es una función tal cual hemos visto, pero tiene ciertas cualidades:

1. Siempre dada la misma entrada de datos debe dar siempre la misma salida, a esto se le llama determinismo.
2. No debe modificar elementos que están fuera de ella.

## Sección 5: Principios SOLID

### 37. Principio de responsabilidad única (Single Responsability Principle)

Es un principio que establece que una clase o un módulo solamente tiene que tener una responsabilidad

### 38. Principio de abierto/cerrado (Open/Closed Principle)

Un módulo de software debe estar abierto para extensión pero al mismo tiempo un módulo debe estar cerrado para su modificación.

Esto quiere decir, que un módulo, siendo este una clase, debería de tener la posibilidad de agregar nueva funcionalidad pero sin que se modifique lo que tiene esta entidad. Esto se logra por medio de abstracciones, es decir, teniendo una interfaz, la interfaz nos indica qué tenemos que hacer mas no cómo hacerlo. Por ejemplo, el envío de un mensaje, el mensaje puede ser enviado por celular, por correo electrónico, puede ser enviado a una base de datos, a un chat, el "cómo" no nos importa, solamente nos interesa que un mensaje puede enviarse, entonces si nosotros queremos extender la funcionalidad del envío de mensajes, hacemos una interfaz que tenga el método enviar y hacemos las clases a partir de esa interfaz con las diferentes funcionalidades de enviar.

### 39. Principio de sustitución de Liskov (Liskov Substitution Principle)

Este principio indica que si "S" es un subtipo de "T", entonces los objetos de tipo "T" en un programa deben de poder ser reemplazados por objetos de tipo "S".

Si se tiene una clase hija de una clase padre y hacemos un objeto a partir de la clase padre, el comportamiento de la clase padre no debería ser alterado, es decir, los métodos existentes en la clase padre, no deberían de tener un comportamiento que haga fallar el programa.

### 40. Principio de segregación de la interfaz (Interface Segregation Principle)

Las clases no deberían estar obligadas a depender de interfaces que tenga métodos que no utilizan

### 41. Principio de inversión de la dependencia (Dependency Inversion Principle)

Los módulos de alto nivel no deben de depender de los módulos de bajo nivel, ambos deben depender de abstracciones.

Los módulos de alto nivel son aquellos que tienen la lógica de negocio, los que hacen que tu aplicación sea tu aplicación, es decir, lo que hace que Uber sea una aplicación que busca un conductor y tengas un viaje, etc. Estos módulos tendrían que depender de abstracciones y no de implementaciones, es decir, deben depender de interfaces y clases abstractas.

Hay cosas que sí van a cambiar mucho y esas cosas que van a cambiar mucho vamos a hacer interfaces. Lo que cambia mucho en un sistema es el cómo se hace mas no lo que hace el sistema, por ejemplo, un sistema como Uber siempre va a buscar un conductor, pero el cómo se busca, podría ser un algoritmo distinto. El qué hace la aplicación de Uber es muy difícil que cambie, entonces esto se puede poner estáticamente en interfaces y donde utilicemos "BuscarConductor", simplemente depender de la interfaz, el cómo se hace podría cambiar, pero al depender de la interfaz, ya no nos importaría que cambie.
