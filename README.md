# Projeto Árvore AVL com Interface Gráfica (Windows Forms)

## Desenvolvedores:
- **Pedro Junior 113538**
- **Gustavo Tesche 113265**

## Faculdade:
- **FHO (Fundação Hermínio Ometto)**

## Disciplina:
- **Análise e projetos orientados a objetos I (APOO 1)**

---

## 📌 O que é este projeto?

Este projeto é uma simulação visual de uma **Árvore AVL** (Árvore de Busca Binária Balanceada), desenvolvida em **C# usando Windows Forms**.

O programa permite ao usuário:
- Inserir números inteiros na árvore AVL.
- Remover números da árvore.
- Buscar números específicos.
- Visualizar a árvore desenhada automaticamente.
- Listar os elementos na ordem Pré-Ordem.
- Exibir os fatores de balanceamento de cada nó.
- Mostrar a altura da árvore.
- Ler comandos de um arquivo `.txt` externo para automatizar operações.

Tudo isso de maneira visual e intuitiva, ideal para facilitar o entendimento de como funciona uma árvore AVL.

---

## 💻 Como usar o programa?

1. Clone ou baixe este repositório:

```
git clone https://github.com/PedrosoY/ProjetoArvoreAVL.git
```


2. Abra a solução (`.sln`) no **Visual Studio 2019 ou superior**.

3. Compile e execute o projeto (pressione **F5**).

4. A interface gráfica será aberta automaticamente.

---

## ⚙️ Funcionalidades disponíveis na interface:

- **Inserir:** Digite um número e clique em "Inserir" para adicioná-lo na árvore.
- **Remover:** Digite um número e clique em "Remover" para excluí-lo da árvore.
- **Buscar:** Digite um número e clique em "Buscar" para verificar se ele existe na árvore.
- **Pré-Ordem:** Mostra todos os números da árvore na ordem Pré-Ordem (Raiz → Esquerda → Direita).
- **Fatores de Balanceamento:** Exibe o fator de balanceamento de cada nó da árvore.
- **Altura:** Exibe a altura total da árvore.
- **Ler de Arquivo:** Lê um arquivo `.txt` com comandos pré-definidos.

---

## 📄 Como funciona o arquivo `.txt`?

Você pode criar um arquivo `.txt` com os seguintes comandos:

```
I numero -> Inserir (exemplo: I 10)
R numero -> Remover (exemplo: R 5)
B numero -> Buscar (exemplo: B 7)
P -> Mostrar Pré-Ordem
F -> Mostrar Fatores de Balanceamento
A -> Mostrar Altura da árvore
```


### Exemplo de arquivo:

```
I 10
I 20
I 15
P
F
A
```


Clique no botão **"Ler Arquivo"** no programa e selecione o arquivo `.txt`.  
O programa executará automaticamente todos os comandos.

---

## 🗂️ Estrutura dos principais arquivos:

- `AVLTree.cs` — Lógica completa da árvore AVL.
- `FormPrincipal.cs` — Interface gráfica e eventos dos botões.
- `Program.cs` — Ponto de entrada do aplicativo.
- `README.md` — Este arquivo de instruções.

---

## 🖥️ Requisitos para compilar:

- Visual Studio 2019 ou superior (Recomendado: Visual Studio 2022)
- .NET 9
- Sistema Operacional: Windows

---

## ℹ️ Observações Importantes:

- Não é necessário saber programar para usar o programa via interface gráfica.
- Projeto criado com fins didáticos para a disciplina de **APOO I**.
- Todos os comandos também podem ser lidos via arquivo `.txt`.
- O desenho da árvore é gerado automaticamente.

---

## 🎓 Projeto Acadêmico:

Desenvolvido como trabalho para a disciplina de  
**Análise e projetos orientados a objetos I**,  
na **Faculdade FHO (Fundação Hermínio Ometto)**,  
pelos alunos **Pedro Junior** e **Gustavo Tesche**.

---
