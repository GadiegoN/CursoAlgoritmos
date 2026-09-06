# Curso de Algoritmos para Jogos

Estudos de algoritmos aplicados a jogos utilizando **Unity e C#**.

## Progresso

- [x] Aula 1 — Fundamentos e movimento
- [x] Aula 2 — Variáveis, condições e input
- [x] Aula 3 — Vetores, distância, perseguição e fuga
- [x] Aula 4 — Máquina de Estados

---

## Aula 1 — Fundamentos e Movimento

Na primeira aula foram apresentados os conceitos básicos do Unity e a estrutura de um projeto.

### Conceitos estudados

- GameObjects
- Components
- Transform
- Scripts em C#
- `Start()`
- `Update()`
- Posição
- Direção
- Velocidade
- `Time.deltaTime`

Foi criado o primeiro movimento:

```csharp
transform.position += Vector3.right * speed * Time.deltaTime;
```

A ideia principal foi entender:

```text
deslocamento = direção × velocidade × tempo
```

e:

```text
nova posição = posição atual + deslocamento
```

---

## Aula 2 — Variáveis, Condições e Input

A segunda aula introduziu lógica de programação e tomada de decisões.

### Conceitos estudados

- Variáveis
- `int`
- `float`
- `bool`
- `if`
- `else`
- Comparadores
- `Debug.Log`
- Input do teclado
- Operador lógico `||`

Foi criado o movimento do Player utilizando **WASD e as setas direcionais**.

Exemplo:

```csharp
if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
{
    transform.position += Vector3.right * speed * Time.deltaTime;
}
```

Também foram feitos exercícios envolvendo vida, ataque e condições de morte.

A estrutura básica estudada foi:

```text
INPUT
  ↓
DECISÃO
  ↓
AÇÃO
```

---

## Aula 3 — Vetores e Matemática para Jogos

A terceira aula foi focada no uso de vetores para representar movimento e relações entre objetos.

### Conceitos estudados

- `Vector3`
- Soma de vetores
- Magnitude
- Normalização
- Direção entre dois objetos
- Distância
- Perseguição
- Fuga
- Operador lógico `&&`

O movimento passou a primeiro calcular uma direção:

```csharp
Vector3 direction = Vector3.zero;
```

As entradas modificam essa direção:

```csharp
direction += Vector3.right;
direction += Vector3.up;
```

Depois ela é normalizada:

```csharp
direction = direction.normalized;
```

Isso evita que o Player se mova mais rápido na diagonal.

### Direção até um alvo

Foi utilizada a relação:

```text
direção até o alvo = posição do alvo - posição atual
```

Em C#:

```csharp
Vector3 direction = target.position - transform.position;
```

### Distância

Foi utilizada:

```csharp
float distance = Vector3.Distance(
    transform.position,
    target.position
);
```

Com esses conceitos foram criados dois comportamentos.

**Perseguição:**

```csharp
transform.position += direction * speed * Time.deltaTime;
```

**Fuga:**

```csharp
transform.position -= direction * speed * Time.deltaTime;
```

Também foi utilizado um intervalo de distância:

```csharp
if (distance < 5 && distance > 0.5f)
```

---

## Aula 4 — Máquina de Estados

Na quarta aula o comportamento do inimigo foi organizado utilizando uma **Máquina de Estados**.

### Conceitos estudados

- Métodos
- Parâmetros
- `enum`
- `switch`
- Estados
- Transições
- Prioridade de condições
- Separação entre decisão e ação

Foram definidos quatro estados:

```csharp
public enum EnemyState
{
    Idle,
    Chase,
    Attack,
    Flee
}
```

O inimigo possui um estado atual:

```csharp
public EnemyState currentState;
```

### Decisão

O estado é escolhido de acordo com a distância:

```csharp
void DecideState(float distance)
{
    if (distance <= fleeRange)
    {
        currentState = EnemyState.Flee;
    }
    else if (distance <= attackRange)
    {
        currentState = EnemyState.Attack;
    }
    else if (distance <= detectionRange)
    {
        currentState = EnemyState.Chase;
    }
    else
    {
        currentState = EnemyState.Idle;
    }
}
```

### Execução

Depois da decisão, o comportamento correspondente é executado:

```csharp
void ExecuteState()
{
    switch (currentState)
    {
        case EnemyState.Idle:
            Idle();
            break;

        case EnemyState.Flee:
            Flee();
            break;

        case EnemyState.Chase:
            Chase();
            break;

        case EnemyState.Attack:
            Attack();
            break;
    }
}
```

O fluxo final ficou:

```text
calcular distância
        ↓
decidir estado
        ↓
executar estado
```

### Estados implementados

```text
Idle   → parado
Chase  → persegue o Player
Attack → estado de ataque
Flee   → foge do Player
```

---

## Conceitos estudados até agora

```text
Movimento
   ↓
Variáveis
   ↓
Condições
   ↓
Input
   ↓
Vetores
   ↓
Magnitude e normalização
   ↓
Distância e direção
   ↓
Perseguição e fuga
   ↓
Métodos
   ↓
Estados
   ↓
Máquina de Estados
```
