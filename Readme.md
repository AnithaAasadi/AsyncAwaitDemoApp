
# Async/Await Demo in .NET

This project demonstrates how `async`, `await`, and `.Result` work in C# with a simple `GetNameAsync()` method. It shows how behavior changes based on how we call the asynchronous method.

---

## ✨ What You’ll Learn

- How to use `async` and `await`
- What happens when you don’t use `await`
- How `.Result` blocks the thread
- Why `await` is preferred in asynchronous programming

---

## 📁 Project Structure

```
AsyncAwaitDemo/
├── Program.cs
└── README.md
```

---

## 🧠 Concepts Covered

### ✅ `await`

Using `await` **pauses the method**, waits for the task to finish, and then continues. It's non-blocking and doesn't freeze the thread.

```csharp
var name = await GetNameAsync();
Console.WriteLine($"Name received (await): {name}");
```

Output:
```
GetNameAsync started
(waiting...)
GetNameAsync finished
Name received (await): Anitha
```

---

### ❌ Without `await`

When you **omit `await`**, the task runs in the background, but the code continues without waiting for it. This often leads to incomplete execution or missed results.

```csharp
var task = GetNameAsync(); // No await
Console.WriteLine("Not waiting for GetNameAsync()");
```

Output:
```
GetNameAsync started
Not waiting for GetNameAsync()
```

The function starts but your program does **not wait** for it to finish. The output might miss the result entirely if the app exits early.

---

### 🧱 `.Result`

`.Result` **blocks the thread** until the task completes. This can freeze your app, especially in UI or Web environments. It's not recommended unless used very carefully.

```csharp
var name = GetNameAsync().Result;
Console.WriteLine($"Name received (.Result): {name}");
```

Output:
```
GetNameAsync started
(waiting synchronously...)
GetNameAsync finished
Name received (.Result): Anitha
```

---

## 📌 Summary Table

| Approach       | Waits? | Blocks Thread? | Use Case                     |
|----------------|--------|----------------|------------------------------|
| `await`        | ✅ Yes | ❌ No           | ✅ Recommended (safe)        |
| No `await`     | ❌ No  | ❌ No           | ❌ Dangerous (unpredictable) |
| `.Result`      | ✅ Yes | ✅ Yes          | ⚠️ Risky (can deadlock)      |

---

## 🔬 Under the Hood

When you use `await`, the compiler **rewrites** your method into a state machine that tracks where it left off. It doesn’t block the thread, just **suspends and resumes** when the awaited task completes.

This allows async code to be efficient and scalable — great for web APIs, UI apps, and I/O-bound operations.

---

## 🛠 How to Run

1. Open terminal
2. Run:
```bash
dotnet watch run
```

You’ll see console output showing the different behaviors of `await`, no-await, and `.Result`.

---

## 🧾 Example Output

```
=== START ===

Calling with await:
[23:09:08.279] 🚀 GetNameAsync() started
[23:09:11.374] ✅ GetNameAsync() finished
[23:09:11.374] Name received (await): Anitha

Calling without await:
[23:09:11.378] 🚀 GetNameAsync() started
[23:09:11.379] ❗ Not waiting for GetNameAsync()

Calling and blocking with .Result:
[23:09:11.380] 🚀 GetNameAsync() started
[23:09:14.386] ✅ GetNameAsync() finished
[23:09:14.386] Name received (.Result): Anitha
```

---

## 💡 Bonus Tip

Always prefer `await` in async methods. Avoid `.Result` unless you're in a **console app or test case** and you know the consequences.

---

## 🙋‍♀️ Author

Anitha – .NET Developer & Async Explorer 💻
