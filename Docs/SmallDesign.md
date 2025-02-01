# Diseño del Juego para Android (Test de Reacción)

## Resolución Objetivo
1080x1920  
## Plataforma
Android  
## Tiempo de Desarrollo
20 horas

## **Esquema General del Juego**

### **Escenas del Juego**

#### 1. **Menú Principal**
- Pantalla inicial con tres botones:
  - **Instrucciones:** Mostrar información sobre el objetivo del juego y cómo jugar.
  - **Test de Reacción:** Comprobar la velocidad de reacción del jugador.
  - **Entrenamiento:** Ofrecer pruebas progresivas para entrenar la velocidad de reacción.

#### 2. **Escena de Instrucciones**
- Descripción clara del juego.
- Explicación detallada de la mecánica del test de reacción y el entrenamiento progresivo.

#### 3. **Escena Test de Reacción**
- Pantalla simple que presenta estímulos visuales.
- Registro del tiempo de reacción del usuario desde que aparece una señal hasta su respuesta.
- Mostrar el resultado del test tras cada intento.

#### 4. **Escena de Entrenamiento**
- Secuencia de pruebas progresivas para mejorar la velocidad de reacción.
- Estímulos visuales cada vez más rápidos y variados.
- Feedback inmediato tras cada intento.

---

## **Detalles de la Jugabilidad**

### **Menú Principal**
- Diseño limpio y minimalista.
- Botones grandes y visibles.
- Animaciones suaves para transiciones entre escenas.

### **Test de Reacción**
- Iniciar con un temporizador oculto.
- Mostrar un estímulo visual aleatorio.
- Medir el tiempo desde la aparición hasta que el jugador toca la pantalla.
- Mostrar resultados con feedback visual (ej. “Excelente”, “Podrías mejorar”).

### **Entrenamiento**
- Serie de niveles progresivos:
  1. **Nivel 1:** Estímulos simples con velocidad moderada.
  2. **Nivel 2:** Aumento de velocidad y estímulos múltiples.
  3. **Nivel 3:** Estímulos más complejos y tiempo reducido.
- El jugador debe responder a los estímulos correctamente antes de que se agote el tiempo.
- Progresión con retroalimentación visual y auditiva.

### **Instrucciones**
- Explicación simple sobre:
  - Cómo reaccionar ante los estímulos.
  - Objetivo del juego.
  - Estrategias para mejorar la velocidad de reacción.
  
---

## **Componentes Clave del Desarrollo**

### 1. **Controlador de Escenas**
- Gestionar las transiciones entre las distintas escenas del juego.

### 2. **Controlador de Test de Reacción**
- Temporizador para medir el tiempo de reacción.
- Registro de resultados y presentación de feedback.

### 3. **Controlador de Entrenamiento**
- Lógica de generación de estímulos.
- Control de respuestas del jugador.
- Registro de progreso.

### 4. **Interfaz de Usuario (UI)**
- Diseño adaptado a móviles (botones grandes, fuentes legibles).
- Feedback visual y auditivo.

### 5. **Animaciones**
- Transiciones suaves.
- Animación de estímulos y feedback visual.

---

## **Distribución del Tiempo (20 horas)**

| Tarea                      | Tiempo Estimado |
|----------------------------|-----------------|
| Configuración del proyecto | 2 horas         |
| Desarrollo del Menú        | 3 horas         |
| Lógica del Test de Reacción| 4 horas         |
| Desarrollo del Entrenamiento | 6 horas       |
| Creación de UI             | 3 horas         |
| Animaciones y Pulido       | 2 horas         |

---

## **Conclusión**
Este diseño de juego busca ofrecer una experiencia entretenida y desafiante en Android, con un enfoque en la mejora progresiva de la velocidad de reacción del jugador. La simplicidad en el diseño permite mantener el desarrollo dentro del límite de 20 horas.

