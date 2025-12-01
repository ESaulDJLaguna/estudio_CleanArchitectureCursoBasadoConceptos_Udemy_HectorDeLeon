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

## Sección 6: Componentes

### 42. ¿Qué es un componente?

Un **componente** es una unidad de software que agrupa un conjunto de funcionalidades **relacionadas entre sí**, de forma que cada componente representa un bloque independiente dentro del sistema (por ejemplo, una biblioteca o _library_). Los componentes permiten **encapsular** funcionalidades específicas y reutilizarlas en diferentes partes del sistema.

En arquitectura, un buen componente debe cumplir dos principios clave:

- **Bajo acoplamiento**: pocas dependencias hacia otros componentes.
- **Alta cohesión**: todo lo que contiene debe estar directamente relacionado.

Cumplir esto facilita el **mantenimiento**, la **extensibilidad** y reduce los efectos colaterales al realizar cambios.

La arquitectura limpia se apoya fuertemente en la **idea de plugins**: componentes intercambiables que pueden quitarse y reemplazarse sin modificar el resto del sistema. Como una pieza de LEGO, un componente puede actualizarse (por ejemplo, cambiando un DLL por otro) sin recompilar ni alterar los componentes que dependen de él.

Esto permite que un sistema escale sin romperse cada vez que se modifica una parte, ya que los cambios se aíslan dentro del componente correspondiente.

### 43. The Reuse-Release Equivalence Principle (REP)

El principio **REP (Reuse-Release Equivalence Principle)** establece que **la unidad mínima de reutilización debe coincidir con la unidad mínima de liberación (release)**. En otras palabras:

> _Un componente solo puede ser realmente reutilizable si se publica y versiona como una unidad coherente._

Este principio se basa en la **cohesión**, es decir, en qué tan relacionados están los elementos dentro de un componente. Un componente con alta cohesión facilita su reutilización, mantenimiento y control de versiones.

#### ¿Qué implica REP?

- Para que un componente sea reutilizable, debe tener un **sistema de versionamiento claro**.
- Cada nueva versión debe indicar sus cambios: funciones nuevas, cambios en parámetros, métodos eliminados o modificados, etc.
- La documentación es parte esencial de un componente reutilizable: quien lo use debe saber **qué versión es compatible** con su sistema.
- Cuando un componente cambia, otros sistemas pueden:
  - quedarse en la versión anterior, o
  - actualizarse y adaptar los cambios necesarios.

#### ¿Por qué es importante?

- Los componentes externos cambian, y no siempre podemos controlarlo.
- Un buen versionamiento permite entender cuándo un cambio es compatible o rompe el comportamiento existente **(breaking change)**.
- Este principio asegura que los componentes tengan una **historia de vida coherente**, facilitando su reutilización sin generar caos o incompatibilidades inesperadas.

En resumen, **un componente no es reutilizable solo porque puede copiarse o referenciarse**, sino porque está **liberado como una unidad completa**, con **versión, documentación y cambios controlados**.

> _En los proyectos de "Biblioteca de clases", podemos ver que al dar clic derecho en ellos y seleccionar "Propiedades", en el apartado de "Paquete" > "General", se tiene un campo llamado "Versión de ensamblado" en el cual podemos establecer la versión para saber qué es lo que tiene al momento de documentar, para decir, "La versión 1.0.0.1 tiene...". Por lo tanto, al compilar el componente (como se vio en la sección anterior) y abrimos las propiedades del .dll en la pestaña "Detalles", podremos ver la versión del archivo que se estableció en las propiedades de la "versión de ensamblado". Es importante tener el versionamiento porque si hacemos un cambio, tenemos que indicarlo._

### 44. The Common Closure Principle (CCP)

El **"Principio de cerrado común" o "Principio de cláusula común"** establece que **las clases que cambian por la misma razón deben agruparse en el mismo componente**.
De forma inversa, **si dos clases cambian por motivos distintos, no deberían estar en el mismo componente**.

Este principio busca que:

- **Los componentes tengan alta cohesión**, es decir, que sus clases estén relacionadas entre sí.
- **Un solo cambio afecte al mínimo número posible de componentes**.
- **Evitar recompilar o desplegar componentes completos cuando el cambio solo afecta a una parte**.

#### Relación con SOLID

El CCP es una extensión del **Single Responsibility Principle (SRP)**, pero aplicado a **componentes**, no a clases:

- **SRP**: cada clase debe tener una única razón para cambiar.
- **CCP**: cada _componente_ debe tener una única razón para cambiar.

Si dentro de un componente existen clases donde un cambio afecta solo a una de ellas, significa que:

- esas clases **no comparten responsabilidad**,
- **no tienen cohesión**,
- y por lo tanto deberían separarse en distintos componentes.

#### ¿Por qué es importante?

- En lenguajes como C#, un componente suele ser un **ensamblado (DLL)**.
- Si un cambio dentro del componente afecta solo a una clase, igualmente hay que recompilar toda la DLL.
- Si esa DLL es usada por otros proyectos, esos proyectos deben actualizar sus referencias, aunque el cambio no les afecte.

Por eso CCP ayuda a:

- reducir impacto de los cambios,
- evitar recompilar o desplegar componentes innecesarios,
- mantener proyectos independientes y estables.

**En esencia**

> **Agrupa clases que cambian juntas.**
>
> **Separa clases que cambian por razones distintas.**

### 45. The Common Reuse Principle (CRP)

Este principio, "Principio de Reutilización Común", establece que las clases que están en un componente, cuando se agrega dicho componente al proyecto principal debería de utilzarse la mayoría de clases de este componente. En otras palabras podría decirse que "No hay que depender de cosas que no se van a utilizar".

Cuando se tiene un mal diseño de componentes, por ejemplo, supongamos que el componente `OperationsComponent` tuviera más clases además de `Operations` e imaginemos que en la aplicación principal solo se utiliza `Operations`, pensemos que alguna de esas otras clases tiene una vulnerabilidad, pero en el proyecto principal NO se está utilizando. Un mal diseño podría acarrear este tipo de problematicas, en las cuales un cambio que no estamos utilizando de alguna utilidad nos afecte. Un buen diseño diría que todas las clases que están dentro del componente `OperationsComponent` tienen una relación tan estrecha que en el proyecto principal la mayoría se están utilizando.

Este principio va muy relacionado al principio SOLID de "segregación de interfaces", en el cual vamos a dividir las clases por los métodos que sí se están utilizando, hacemos la interfaz con los métodos que en el contexto sí están siendo utilizados y si hay métodos que en una interfaz no están siendo utilizados por una clase, dividimos en otra interfaz.

### 46. The Acyclic Dependencies Principle (ADP)

A partir de ahora se verán tres principios que tiene que ver con el **acoplamiento**. Un acoplamiento entre componentes debe ser lo más bajo posible, es decir, si se modifica un componente, debería de afectar lo mínimo a otros componentes.

Veremos el "Principio acíclico de dependencias". Imaginemos que tenemos 3 componentes: A, B y C, supongamos que A depende de B; B depende de C y C depende de A. Esto es un problema enorme, porque se tiene un ciclo y lo que queremos lograr con este principio es romper los ciclos. ¿Qué pasaría si C falla? Pues B no podría funcionar porque dependen de C, mientras que A tampoco podría funcionar porque requiere de B y a su vez C no podrá funcionar porque necesita de A. Para solucionar esto existen dos manera: 1) es crear una dependencia abstracción y no dependencia implementación, es decir, tenemos el componente A que depende del componente B que a su vez depende de C, pero C NO va a depender de A sino de una interfaz de A (IA), de esta manera IA hará la implementación del componente A. 2) la segunda forma de solucionar es crear un cuarto componente, es decir, A depende de B, B depende de C y finalmente, A y C dependerán del nuevo componente D. De ambas soluciones, es más recomendable la primera alternativa.

### 47. The Stable Dependencies Principle (SDP)

El **Principio de Dependencias Estables** establece que:

> **Los componentes difíciles de cambiar (estables) deben depender únicamente de otros componentes que sean incluso más estables que ellos.**

En cualquier sistema existen componentes que cambian con frecuencia, por ejemplo:

- La capa de **interfaz de usuario**
- La capa de **lógica de negocio**
- Cualquier módulo donde constantemente se agregan funcionalidades

Estos componentes son **volátiles**, por lo que **no es buena idea que otros módulos dependan de ellos**, ya que cada cambio podría obligar a recompilar y modificar múltiples lugares del sistema.

#### Ejemplo conceptual

Supongamos que tenemos los componentes:

- **A, B y C** los cuales dependen del componente **D**

En ese caso, **D debería ser muy estable**, ya que cualquier cambio en D obligaría a cambiar A, B y C.

Por eso D debe ser un componente que:

- Cambia poco
- Tiene razones sólidas para permanecer estático
- Sirve como base para otros módulos

#### Problema: Un componente estable depende de uno inestable

En un mal diseño puede ocurrir que:

- Un componente que **debería ser estable** (S)
- Dependa de un componente **flexible / volátil** (F)

Esto es un gran problema porque:

- F cambia constantemente
- Cada cambio en F provoca cambios en S
- Y por consecuencia, cambios en todos los componentes que dependen de S

Es decir: **un componente volátil arrastra al resto**, aumentando el acoplamiento y la fragilidad del sistema.

#### Solución: aplicar el principio SOLID de Inversión de Dependencias (DIP)

Para corregir el problema, se incorpora un **nuevo componente A (abstracciones)** que contiene **solo interfaces**.

El rediseño queda así:

1. **El componente estable (S) depende de interfaces**, no de implementaciones concretas.
2. **El componente flexible (F)** implementa esas interfaces.
3. Ambas dependencias apuntan a un módulo común de **abstracciones**.

Beneficios:

- S ya no depende directamente de F.
- F puede cambiar muchas veces sin afectar a S.
- Se pueden tener múltiples implementaciones (F1, F2, F3…) sin modificar S.
- Se reduce el acoplamiento y se minimizan los cambios.

#### Resumen final

El SDP busca que:

- Los componentes estables estén en la base de la arquitectura.
- Los componentes volátiles dependan de los estables, no al revés.
- Se utilicen **interfaces** para invertir dependencias y evitar acoplamiento innecesario.
- Se reduzcan los cambios globales en sistemas grandes.

Aplicando este principio se consigue una arquitectura más robusta, flexible y fácil de mantener.

### 48. The Stable Abstractions Principle (SAP)

El **Principio de Abstracción Estable** indica que los **componentes más estables** (los que **rara vez cambian**) deben ser **más abstractos**, es decir, estar compuestos principalmente por **interfaces y clases abstractas**. Por el contrario, los **componentes menos estables** (los que **cambian frecuentemente**) deben ser **más concretos**, es decir, contener la implementación mediante **clases**.

#### ¿Por qué?

Porque cuando diseñamos un sistema sin experiencia, suele mezclarse código estable con código cambiante, lo que rompe la cohesión y provoca que pequeños cambios obliguen a modificar varios componentes.

El objetivo es **minimizar el impacto del cambio**, asegurando que lo que cambia dependa de lo que no cambia —y no al revés—.

#### Ejemplo práctico

##### Componente estable (abstracto): Autenticación

Un componente que define **qué es autenticar** normalmente cambia muy poco.

- Interfaz: IAuth
- Método: Login(user, password)

El contrato es casi universal: usuario + contraseña (o equivalentes).
Por eso este componente debe ser **abstracto** y contener principalmente **interfaces**.

##### Componente inestable (concreto): Implementaciones de autenticación

La forma de autenticar puede cambiar según reglas del negocio:

- Autenticación contra base de datos
- Autenticación contra un servicio externo
- Nuevas validaciones, reglas, etc.

Este componente debe contener **clases concretas** que implementan la interfaz IAuth, ya que es donde se producen los cambios.

#### Identificando componentes estables

Con la experiencia se reconocen contratos que rara vez cambian:

- Operaciones básicas de base de datos: **agregar, actualizar, eliminar, obtener**.
- Acción de enviar un mensaje, correo o notificación.
- Definiciones de procesos que casi siempre se mantienen constantes.

Estos deben ser **componentes abstractos**, formados principalmente por **interfaces**.

#### Identificando componentes inestables

Son componentes donde los cambios son frecuentes:

- La **interfaz de usuario (UI)**
- Servicios con reglas de negocio cambiantes
- Implementaciones específicas de bases de datos
- Integraciones externas

Estos deben tener **clases concretas** y no deben depender de otros componentes inestables para no multiplicar el impacto del cambio.

#### Objetivo general

Reducir la cantidad de componentes que deben modificarse ante un cambio.
Los principios revisados (incluyendo este) buscan:

- Mantener **cohesión**
- Lograr **bajo acoplamiento**
- Conseguir **alta estabilidad en los componentes fundamentales**
