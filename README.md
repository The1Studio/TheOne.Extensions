# TheOne.Extensions

Common extension methods for Unity

## Installation

### Option 1: Unity Scoped Registry (Recommended)

Add the following scoped registry to your project's `Packages/manifest.json`:

```json
{
  "scopedRegistries": [
    {
      "name": "TheOne Studio",
      "url": "https://upm.the1studio.org/",
      "scopes": [
        "com.theone"
      ]
    }
  ],
  "dependencies": {
    "com.theone.extensions": "1.1.0"
  }
}
```

### Option 2: Git URL

Add to Unity Package Manager:
```
https://github.com/The1Studio/TheOne.Extensions.git
```

## Features

- Collection extensions (Dictionary, Enumerable, etc.)
- Unity-specific extensions (Transform, Vector, Color, etc.)
- Coroutine and UniTask extensions
- Serializable data structures
- Utility classes and helpers
- Addressables extensions

## Usage

### Collection Extensions

```csharp
using TheOne.Extensions;

// List extensions with Index support
list.RemoveAt(^1); // Remove using System.Index
list.RemoveAtSwapBack(0); // Remove efficiently without shifting
list.RemoveRange(start, stop); // Remove range of elements
list.AddRange(items); // Add multiple items

// Stack extensions
stack.PeekOrDefault(); // Safe peek with default
stack.PopOrDefault(defaultValue); // Safe pop with default
stack.Clear(action); // Clear with action on each item

// Dictionary extensions
dict.GetOrDefault(key); // Returns default(T) if not found
dict.GetOrDefault(key, defaultValue);
dict.GetOrAdd(key, () => new Value()); // Get or create with factory
dict.RemoveOrDefault(key); // Remove and return value or default
dict.RemoveWhere((k, v) => predicate); // Remove by predicate

// Enumerable extensions
items.ForEach(action); // Execute action on each item
items.SafeForEach(action); // ToArray then ForEach (for collection modification)
items.MinBy(x => x.Score); // Get item with min score
items.MaxBy(x => x.Score); // Get item with max score
items.FirstIndexOrDefault(predicate); // Get index of first match
items.Flat(); // Flatten IEnumerable<IEnumerable<T>>

// Enumerable with null handling
items.MinOrDefault(); // Min with default if empty
items.MaxOrDefault(defaultValue);
items.AggregateFromFirst(func); // Aggregate starting from first element
```

### Unity Extensions

```csharp
// Transform position/rotation/scale
transform.SetPositionX(10f); // Set only X component
transform.SetPositionY(5f);
transform.SetPositionZ(0f);
transform.SetLocalPositionX(10f);
transform.SetEulerAngleY(90f); // Set rotation
transform.SetLocalEulerAngleZ(45f);

// GameObject/Component extensions
gameObject.DontDestroyOnLoad(); // Persist across scenes
gameObject.GetComponentOrDefault<T>(); // Safe GetComponent
gameObject.GetComponentOrThrow<T>(); // GetComponent or exception
gameObject.HasComponent<T>(); // Check if has component
gameObject.GetComponentInChildrenOrDefault<T>();
gameObject.Instantiate(position, rotation, parent);

// Object extensions
obj.Destroy(); // Destroy Unity Object
obj.DestroyImmediate(); // Immediate destroy

// Vector extensions
vector2.WithX(5f); // Returns vector with new X value
vector3.WithY(10f); // Returns vector with new Y value
vector3.WithZ(0f); // Returns vector with new Z value

// Color extensions
color.WithAlpha(0.5f); // Returns color with new alpha
color.ToHex(); // Convert to hex string
graphic.SetAlpha(0.8f); // Set alpha on UI Graphic
spriteRenderer.SetColor(Color.red); // Set color on SpriteRenderer

### Async Extensions

```csharp
// Coroutine extensions (when UniTask not available)
#if !THEONE_UNITASK
StartCoroutine(DoWork().Then(() => Debug.Log("Done"))); // Chain callback
StartCoroutine(DoWork().Then(DoMoreWork())); // Chain coroutines
StartCoroutine(DoWork().Catch(ex => Debug.LogError(ex))); // Error handling
StartCoroutine(tasks.WhenAll()); // Wait for all
StartCoroutine(tasks.WhenAny()); // Wait for any

// Task to Coroutine conversion
StartCoroutine(myTask.AsCoroutine());
#endif

// UniTask extensions (when available)
#if THEONE_UNITASK
await tasks.WhenAll(); // Parallel execution
await tasks.WhenAny(); // Race condition
await Task.Delay(1000).AsUniTask(); // Convert Task to UniTask
#endif
```

### Serializable Collections

```csharp
// Use in Inspector
[System.Serializable]
public class GameData
{
    public SerializableDictionary<string, int> scores;
    public SerializableReadOnlyList<string> levels;
    public Serializable2DArray<float> grid;
    public SerializableTuple<int, string> playerInfo;
}
```

## Architecture

### Folder Structure

```
TheOne.Extensions/
├── Scripts/
│   ├── CollectionExtensions.cs           # List, array, collection utils
│   ├── DictionaryExtensions.cs           # Dictionary specific extensions
│   ├── EnumerableExtensions.cs           # LINQ-like operations
│   ├── ParallelEnumerableExtensions.cs   # Parallel processing
│   ├── StringExtensions.cs               # String manipulation
│   ├── DateTimeExtensions.cs             # Date/time utilities
│   ├── ReflectionExtensions.cs           # Reflection helpers
│   ├── TupleExtensions.cs                # Tuple utilities
│   ├── VContainerExtensions.cs           # VContainer specific
│   ├── Coroutine/                        # Coroutine utilities
│   │   ├── CoroutineExtensions.cs
│   │   ├── CoroutineRunner.cs
│   │   └── [Collection]CoroutineExtensions.cs
│   ├── UniTask/                          # UniTask extensions
│   │   ├── UniTaskExtensions.cs
│   │   └── [Collection]UniTaskExtensions.cs
│   ├── Unity/                            # Unity-specific
│   │   ├── TransformExtensions.cs
│   │   ├── VectorExtensions.cs
│   │   ├── ColorExtensions.cs
│   │   ├── QuaternionExtensions.cs
│   │   └── UnityExtensions.cs
│   ├── Addressables/                     # Addressables support
│   │   └── AddressablesExtensions.cs
│   ├── Indexing/                         # Index/Range support
│   │   ├── EnumerableExtensions.cs
│   │   └── TupleExtensions.cs
│   ├── Serializables/                    # Serializable collections
│   │   ├── SerializableDictionary.cs
│   │   ├── SerializableReadOnlyList.cs
│   │   ├── Serializable2DArray.cs
│   │   └── SerializableTuple.cs
│   └── Utilities/                        # Utility classes
│       ├── BetterMonoBehavior.cs
│       ├── Deque.cs
│       ├── PriorityQueue.cs
│       ├── Progress.cs
│       ├── Range.cs
│       ├── Item.cs
│       ├── KeyAttribute.cs
│       └── Operator.cs
```

### Core Extension Categories

#### Collection Extensions
- **Efficient Operations**: `RemoveAtSwapBack`, `AddRange`, `InsertRange`
- **Sampling**: `Sample`, `Shuffle`, `Random`
- **Indexing**: Support for `System.Index` and `System.Range`
- **Functional**: `ForEach`, `TryFirst`, `TryLast`

#### Dictionary Extensions
- **Safe Access**: `GetValueOrDefault`, `TryRemove`
- **Lazy Initialization**: `GetOrAdd` with factory
- **Bulk Operations**: `AddRange`, `RemoveRange`
- **Conversion**: `ToReadOnlyDictionary`, `Inverse`

#### Enumerable Extensions
- **Filtering**: `WhereNotNull`, `DistinctBy`, `ExceptBy`
- **Aggregation**: `MaxBy`, `MinBy`, `Sum` with selector
- **Partitioning**: `ChunkBy`, `Split`, `Batch`
- **Materialization**: `ToHashSet`, `ToReadOnlyList`

#### Unity-Specific Extensions
- **Transform Helpers**: Position/rotation/scale manipulation
- **Component Management**: `GetOrAddComponent`, `TryGetComponent`
- **Hierarchy**: `GetChildren`, `GetParents`, `DestroyChildren`
- **Math**: Vector operations, color manipulation, quaternion utils

### Design Patterns

- **Extension Methods**: Non-invasive functionality additions
- **Fluent Interface**: Chainable method calls
- **Null Safety**: Null-aware operations
- **Performance Focus**: Optimized algorithms
- **Unity Integration**: Respects Unity's lifecycle

### Code Style & Conventions

- **Namespace**: All under `TheOne.Extensions`
- **Null Safety**: Uses `#nullable enable`
- **Method Naming**: Descriptive, action-oriented names
- **Overloading**: Multiple signatures for flexibility
- **Generic Constraints**: Appropriate type constraints
- **Documentation**: XML comments for IntelliSense

### Performance Optimizations

```csharp
// Efficient removal without shifting elements
list.RemoveAtSwapBack(index); // O(1) instead of O(n)

// Safe iteration with modification
collection.SafeForEach(item => {
    // Can safely modify collection during iteration
    if (item.ShouldRemove) collection.Remove(item);
});

// Lazy evaluation with default values
var result = dict.GetOrDefault(key); // No exception overhead
var value = stack.PeekOrDefault(); // Safe peek without try-catch

// Minimal allocation patterns
items.ForEach(ProcessItem); // No LINQ allocation
items.FirstIndexOrDefault(predicate); // Direct index search
```

### Utility Classes

#### `BetterMonoBehavior`
Enhanced MonoBehaviour with null-safe component access and async utilities:
```csharp
public class MyComponent : BetterMonoBehavior
{
    void Start()
    {
        // Null-safe component access
        var renderer = this.GetComponentOrDefault<Renderer>();
        var hasCollider = this.HasComponent<Collider>();
        
        // Safe component search in hierarchy
        var parentScript = this.GetComponentInParentOrDefault<ParentScript>();
        var childUI = this.GetComponentInChildrenOrDefault<UIElement>();
        
        // Async utilities based on compilation symbols
        #if THEONE_UNITASK
        var token = this.GetCancellationTokenOnDisable();
        DoAsyncWork(token).Forget();
        #else
        StartCoroutine(DoCoroutineWork());
        var parallel = GatherCoroutines(Coroutine1(), Coroutine2());
        StartCoroutine(parallel);
        #endif
    }
}
```

#### `Deque<T>`
Double-ended queue for efficient front/back operations:
```csharp
var deque = new Deque<int>();
deque.PushFront(1);    // Add to front: [1]
deque.PushBack(2);     // Add to back: [1, 2]
deque.PushFront(0);    // Add to front: [0, 1, 2]

var front = deque.PopFront();  // Remove from front: 0, deque: [1, 2]
var back = deque.PopBack();    // Remove from back: 2, deque: [1]
var peek = deque.PeekFront();  // Look at front: 1, deque unchanged

Debug.Log($"Count: {deque.Count}"); // 1
```

#### `PriorityQueue<TItem, TPriority>`
Priority queue with custom comparison support:
```csharp
// Min-heap (default)
var minQueue = new PriorityQueue<string, int>();
minQueue.Enqueue("low", 1);
minQueue.Enqueue("high", 10);
minQueue.Enqueue("medium", 5);
var lowest = minQueue.Dequeue(); // "low"

// Max-heap with custom comparison
var maxQueue = new PriorityQueue<Task, int>((a, b) => b.CompareTo(a));
maxQueue.Enqueue(urgentTask, 10);
maxQueue.Enqueue(normalTask, 5);
var mostUrgent = maxQueue.Dequeue(); // urgentTask

// Complex priority objects
var taskQueue = new PriorityQueue<GameTask, Priority>();
taskQueue.Enqueue(renderTask, new Priority(1, DateTime.Now));
var nextTask = taskQueue.Peek(); // Look without removing
```

#### `Progress`
Thread-safe progress reporting with validation:
```csharp
var progress = new Progress(value => 
{
    Debug.Log($"Loading: {value:P}");
    loadingBar.fillAmount = value;
});

// Reports progress from 0.0 to 1.0
progress.Report(0.0f);   // 0%
progress.Report(0.5f);   // 50%
progress.Report(1.0f);   // 100%

// Sub-progress for parallel operations
var subProgresses = progress.CreateSubProgresses(3);
await UniTask.WhenAll(
    LoadAssets(subProgresses[0]),
    LoadScenes(subProgresses[1]),
    LoadData(subProgresses[2])
);
```

#### `Ranges`
Python-style range generation for loops and sequences:
```csharp
// Simple ranges
foreach (int i in Ranges.Take(5))           // 0, 1, 2, 3, 4
foreach (int i in Ranges.To(5))             // 0, 1, 2, 3, 4
foreach (int i in Ranges.From(2).To(5))     // 2, 3, 4
foreach (int i in Ranges.From(1).Take(3))   // 1, 2, 3

// Practical usage
var indices = Ranges.Take(enemies.Count).ToArray();
var layers = Ranges.Take(10).Select(i => $"Layer_{i}").ToArray();
var positions = Ranges.From(startIndex).Take(count)
    .Select(i => CalculatePosition(i));
```

#### `Item`
Static utility methods for common type checks and operations:
```csharp
// Type checking helpers
if (Item.Is<Enemy>(target)) { /* target is Enemy */ }
if (Item.IsNot<Player>(entity)) { /* entity is not Player */ }

// Null checking with proper annotations
if (Item.IsNotNull(component)) { /* component is guaranteed non-null */ }
if (Item.IsNull(optionalValue)) { /* optionalValue is null */ }

// Boolean helpers for readability
var activeEnemies = enemies.Where(Item.IsTrue(e => e.IsActive));
var inactiveItems = items.Where(Item.IsFalse(item => item.IsEnabled));

// Identity function for type inference
var typedValue = Item.S<SpecificType>(someValue);
```

#### `Operator`
Static methods for functional programming with LINQ and aggregation operations:
```csharp
// Primary usage: LINQ aggregations and functional operations
var totalScore = scores.Aggregate(Operator.Add);           // Sum all scores
var maxValues = list1.Zip(list2, Operator.Max);           // Element-wise max
var differences = list1.Zip(list2, Operator.Difference);   // Element-wise diff

// Accumulate operations
var runningTotals = values.Accumulate(Operator.Add);       // [1, 3, 6, 10, ...]
var maxSoFar = values.Accumulate(Operator.Max);          // [5, 5, 8, 8, ...]

// Vector aggregations
var boundingBox = positions.Aggregate(Operator.Max);       // Find max bounds
var centerOfMass = positions.Aggregate(Operator.Add) / count;

// Boolean logic in collections  
var allConditions = flags.Aggregate(Operator.And);        // All must be true
var anyCondition = flags.Aggregate(Operator.Or);         // Any can be true

// Supports all numeric types: int, long, uint, ulong, float, double, decimal
// And Unity types: Vector2, Vector3, Vector4, Vector2Int, Vector3Int
// Designed for functional composition, not direct arithmetic
```

#### `IterTools`
Advanced iteration utilities inspired by Python's itertools:
```csharp
// Strict zip (same length required)
var pairs = IterTools.Zip(names, ages);        // [(name1, age1), (name2, age2)]
var triples = IterTools.Zip(x, y, z);          // [(x1, y1, z1), ...]

// Flexible zip variants
var shortest = IterTools.ZipShortest(list1, list2);  // Stops at shortest
var longest = IterTools.ZipLongest(list1, list2);    // Continues with nulls

// Cartesian product
var coordinates = IterTools.Product(xValues, yValues);  // All (x,y) combinations
var combinations = IterTools.Product(colors, sizes, materials);

// Permutations and combinations
var arrangements = IterTools.Permutations(items, 3);           // All 3-item arrangements
var groups = IterTools.Combinations(players, 2);              // All 2-player teams
var withReplacement = IterTools.CombinationsWithReplacement(dice, 2);

// Factory methods
var defaults = IterTools.Repeat(() => new GameObject(), 10);   // 10 new GameObjects
IterTools.Repeat(() => ProcessFrame(), frameCount);           // Repeat action
```

#### `KeyAttribute`
Type identification for resource loading and entity management:
```csharp
[Key("player_prefab")]
public class Player : MonoBehaviour { }

// Used by TheOne.Entities for automatic prefab resolution
entityManager.Spawn<Player>();  // Uses "player_prefab" key automatically
```

## Performance Considerations

- Extension methods have zero overhead
- Lazy evaluation where appropriate
- Struct enumerators to avoid boxing
- Cached delegates for repeated operations
- Conditional compilation for platform-specific code

## Best Practices

1. **Import Namespace**: Always `using TheOne.Extensions;`
2. **Null Checks**: Use null-aware extensions like `WhereNotNull()`
3. **Performance**: Use specialized methods like `RemoveAtSwapBack` when order doesn't matter
4. **Async Preference**: Use UniTask extensions when available
5. **Collection Choice**: Use appropriate serializable collections for Inspector
6. **Memory**: Be mindful of LINQ materializations with `ToList()`, `ToArray()`
7. **Unity Lifecycle**: Respect Unity's threading model with async operations