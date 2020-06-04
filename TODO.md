# TODO List:
+ Bugfix: to set end of a section
+ Feature: to handle PUSH & ORG & POP

# Note:
```
Stan 昨天晚上7点29分
How hard do you think it would be for you to make those work by outputting those .ARM.__at_address sections (that may not work with gnu ld?) (or some other formatted section name, whatever works)?
Like PUSH; ORG $1234; WORD $DEADBEEF; POP would output .pushsection .ARM.__at_08001234, "ax"; .word 0xDEADBEEF; .popsection or something?
Stan 昨天晚上8点26分
so you do
.pushsection .ARM.__at_0808388E, "ax"
    nop
.popsection
so you do
.section .ARM.__at_0808388E, "ax"
    nop
.previous
Stan 昨天晚上8点50分
PUSH; ORG Somewhere
    POIN MyHackThing
POP
// Free Space
ALIGN 4
MyHackThing:
    // Data
if you ignore the POP you are not writing in free space anymore
and that's a pretty big problem
Stan 昨天晚上9点12分
.section .ARM.__at_0808388E, "ax"
    nop
.previous
Stan 昨天晚上9点17分
(using .pushsection/.popsection may be better than .previous tho but yes)
```