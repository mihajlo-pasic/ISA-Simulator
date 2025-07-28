# 🖥️ Instruction Set Architecture Simulator

This project is a custom **Instruction Set Architecture (ISA) simulator**, developed as part of a **Computer Architecture** course.  
The simulator is written in **C#** and functions as an interpreter for a simple assembly language.

---

## ✅ Implemented Features

### 1. General Purpose Registers

- The simulated machine contains **4 general-purpose 64-bit registers**.
- Registers are implemented using C#'s `long` data type to represent 64-bit values.

---

### 2. Instruction Set

#### 🧮 Arithmetic Operations
- `ADD` – Addition  
- `SUB` – Subtraction  
- `MUL` – Multiplication  
- `DIV` – Division  

#### 🔣 Bitwise Logical Operations
- `AND`, `OR`, `XOR`, `NOT`

#### 📥 Data Movement
- `MOV` – Move data between registers or between register and memory  
- `LOAD`, `STORE` – Memory access with both **direct** and **indirect** addressing

#### ⌨️ I/O Operations
- `IN` – Read input from standard input  
- `OUT` – Output value to standard output

#### 🔁 Control Flow
- `JMP` – Unconditional jump  
- `CMP` – Compare two register values  

**Conditional Jumps**:  
- `JE` – Jump if equal  
- `JNE` – Jump if not equal  
- `JGE` – Jump if greater or equal  
- `JL` – Jump if less  

---

### 3. 🧠 Memory Simulation

- Simulated 64-bit address space  
- Each memory location stores **1 byte**
- Supports both **direct** and **indirect** memory addressing
- Read and write support for all memory addresses via `MOV`, `LOAD`, and `STORE` instructions

---

### 4. 📄 Assembly Code Input

- The simulator reads **assembly source code** from a text file
- Performs:
  - **Lexical analysis**
  - **Syntax analysis**
  - **Semantic analysis**
- Executes the validated code as an interpreter

---
