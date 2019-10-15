# CQRS: Command Query Responsibility Segregation
## Event Sourcing, and Domain Driven Design

#Background

CQRS is not an entire architecture, but is just a small pattern.

The main idea behind CQS is: “A method should either change state of an object,
or return a result, but not both. In other words, asking the question should not
change the answer. More formally, methods should return a value only if they are
referentially transparent and hence possess no side effects.” (Wikipedia)

Because of this we can divide methods into two sets:
- *Commands:* change the state of an object or entire system.
- *Queries:* return results and do not change the state of an object.
