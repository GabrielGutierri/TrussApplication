# 🏗️ TrussApplication

A Windows Forms desktop application developed in **C# / .NET 6** for structural analysis of trusses. The user builds a custom truss interactively on screen, applies external forces, and the system resolves all internal bar forces and support reactions using classical structural mechanics.

---

## 📐 What it does

The application simulates the static analysis of a 2D truss structure. The user defines the truss geometry from scratch — placing nodes, connecting bars, assigning supports and external loads — and the system automatically computes:

- **Support reactions** (fixed and mobile supports)
- **Internal forces per bar** (tension or compression)
- **Force vectors and components** at each node

The calculation engine handles forces in any direction: vertical, horizontal, and inclined (resolved into X/Y components via trigonometry), across all four quadrants.

---

## ✨ Features

- Interactive truss creation directly on the canvas — click to place nodes
- Add bars between any two existing nodes
- Apply point forces with custom intensity, direction, and angle
- Define fixed supports (2 reaction components) and mobile supports (1 reaction component)
- Automatic calculation of support reactions via moment equilibrium
- Iterative node-by-node resolution of internal bar forces (method of joints)
- Handles simple equations (1 unknown) and system of equations (2 unknowns — "Ninja Method")
- User login and registration backed by SQL Server (Azure)
- Built-in help dialogs explaining how to add bars, forces, and supports

---

## 🧮 Calculation Method

The engine applies the **Method of Joints** iteratively:

1. **Moment equilibrium** around the fixed support is used to find the mobile support reaction.
2. **Force equilibrium** at the fixed support resolves the remaining horizontal and vertical reactions.
3. **Each node** is analyzed starting from those with at most 2 unknown bar forces:
   - If 1 unknown → simple trigonometric equation.
   - If 2 unknowns → simultaneous equations (Cramer's rule applied via sine/cosine decomposition).
4. The loop repeats until all bar forces are resolved, or a maximum iteration cap is reached.

Force orientation (tension vs. compression) is determined by the sign of the resolved intensity — negative results flip the orientation from "Pointing inward" to "Pointing outward".

---

## 🗂️ Project Structure

```
TrussApplication/
├── Bar/
│   └── Bar.cs                        # Bar model (endpoints, angle, direction, quadrant)
├── Points/
│   ├── Point.cs                      # Node model (coordinates, bars, forces, supports)
│   └── ArrowPoint.cs                 # Visual arrow representation
├── Forces/
│   ├── Force.cs                      # Abstract base class (intensity, components, orientation)
│   ├── BarForce.cs                   # Force on a structural bar
│   ├── PointForce.cs                 # External force applied to a node
│   └── SupportForce.cs              # Reaction force at a support
├── Calculos/
│   ├── Calculation.cs                # Orchestrator: moment equilibrium + support resolution
│   ├── CalculateBarForces.cs         # Method of joints — iterative bar force resolution
│   ├── CalculateFixedForces.cs       # Fixed support vertical and horizontal components
│   ├── MomentCalculationLeft.cs      # Moment contributions for nodes left of the fixed support
│   └── MomentCalculationRight.cs     # Moment contributions for nodes right of the fixed support
├── Forms/
│   ├── Form1                         # Main canvas — truss drawing and calculation trigger
│   ├── frmLogin / frmRegister        # Authentication screens
│   ├── frmCreation                   # Node action selector (add bar / force / support)
│   ├── AddBars                       # Bar creation form
│   ├── frmAddForce                   # Force configuration form
│   ├── AddSupport                    # Support type selection form
│   ├── frmDelete                     # Element deletion form
│   ├── About                         # About screen
│   └── Help* forms                   # Contextual help dialogs
├── Helpers/
│   └── Validations.cs                # Input validation utilities
└── Resources/                        # Icons and images used in the UI
```

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Language | C# |
| Framework | .NET 6 (Windows) |
| UI | Windows Forms |
| Database | SQL Server (Azure) via `System.Data.SqlClient` |
---

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (with Windows Forms workload)
- SQL Server connection (or configure a local instance in `frmLogin.cs`)
