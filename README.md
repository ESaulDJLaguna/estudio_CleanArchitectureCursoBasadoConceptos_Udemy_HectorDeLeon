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
