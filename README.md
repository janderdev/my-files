# Arquitetura Hexagonal (Ports and Adapters)

A arquitetura hexagonal, também conhecida como **arquitetura de portas e adaptadores** (*Ports and Adapters architecture*), é um padrão de arquitetura de software que promove a criação de sistemas altamente flexíveis e desacoplados. Essa abordagem facilita a manutenção, a testabilidade e a evolução do código.

## Componentes da Arquitetura Hexagonal

### 1. Portas (*Ports*)
As portas são interfaces que definem como o sistema interage com o mundo externo. Elas incluem interações com usuários, outros sistemas e recursos externos. No contexto deste projeto, as portas representam as **interfaces de entrada e saída** que conectam o núcleo do sistema às dependências externas.

### 2. Adaptadores (*Adapters*)
Os adaptadores são responsáveis por implementar as interfaces definidas pelas portas. Eles traduzem solicitações e respostas entre o núcleo do sistema e o mundo externo. No projeto, exemplos de adaptadores incluem:
- Interfaces REST para comunicação com APIs externas
- Adaptadores para persistência de dados (bancos de dados)
- Adaptadores para integração com serviços de terceiros

### 3. Núcleo (*Core*)refactor: reorganize folders for simple hexagonal architecture

O núcleo contém a **lógica de negócios** e é completamente independente de tecnologias externas. Ele é projetado para ser reutilizável e testável, garantindo que mudanças em adaptadores ou portas não impactem diretamente a lógica central. No projeto, o núcleo inclui:
- Regras de negócio
- Casos de uso
- Entidades principais

---

Essa arquitetura foi escolhida para este projeto devido à sua capacidade de promover um design modular e sustentável, permitindo que mudanças em tecnologias externas sejam realizadas sem comprometer a lógica central do sistema.
