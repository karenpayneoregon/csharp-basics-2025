# Copilot / AI Agent Instructions for CommonHelpersLibrary

- Repo type: small .NET class library targeting net9.0 (`CommonHelpersLibrary.csproj`).
- Purpose: collection of tiny helpers (assembly-info helpers in `Info.cs`, boolean extension in `BoolExtensions.cs`) intended to be referenced by other projects.

What to prioritize
- Keep changes small and focused; this is a single-purpose library. Typical PRs will add small helpers or improve accuracy of metadata reporting in `Info.cs`.
- Preserve public API stability: maintain method signatures in `Info` and `BoolExtensions` unless the change is a deliberate major-version update.

Project structure and important files
- `CommonHelpersLibrary.csproj` — single-target net9.0, no extra packages or build props.
- `Info.cs` — core utility for extracting calling assembly metadata. Follow its patterns: use [MethodImpl(MethodImplOptions.NoInlining)] on callers that inspect the call stack; use Caller Info attributes for optional out parameters.
  - Example pattern: `GetCompany(out var caller, [CallerMemberName] ...)` populates `CallerDetails` using `Assembly.GetCallingAssembly()` and a best-effort `StackTrace` lookup.
- `BoolExtensions.cs` — tiny extension method `ToYesNo` that returns "Yes" or "No".
- `readme.md` — surface-level project description (keep in sync with public API changes).

Build & test
- Build locally with the standard dotnet CLI from the repo root where the `.csproj` lives:

```powershell
dotnet build -c Debug
```

- There are no unit tests present. If you add tests, create an xUnit or NUnit test project targeting net9.0 and add it to the solution manually.

Conventions & patterns
- API and naming: prefer small, single-responsibility static helpers and extension methods (see `BoolExtensions.cs`).
- Caller info & stack inspection: methods that expose caller context use `MethodImplOptions.NoInlining` and Caller Info attributes. Preserve these attributes when modifying behavior.
- No external dependencies: keep new features lightweight and dependency-free unless necessary.

Integration points
- Library is intended to be referenced by other .NET projects to read assembly metadata at runtime; it uses reflection and optional StackTrace frame inspection. Be mindful that `Assembly.GetCallingAssembly()` behavior differs under certain runtimes and inlined methods — the existing use of `NoInlining` and StackTrace is deliberate to improve accuracy.

When editing code
- Keep changes minimal and document the rationale in the PR description.
- Update `readme.md` for user-facing behavior changes.
- If you change public behavior, include a small example in `readme.md` showing the typical usage (e.g., `Info.GetCompany(out var caller)` example).

Non-goals
- This repo is not a full application — avoid adding hosting, DI, or web frameworks.

If anything is unclear or you need more examples from the codebase, ask and I will update these instructions.