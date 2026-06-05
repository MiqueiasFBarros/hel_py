vida_chefe = 100
ataque_base = 20
turno = 1

print("Um Chefe apareceu! Vida inicial:")
print(vida_chefe)

if vida_chefe > 0:
    print("Iniciando o combate...")

    while vida_chefe > 0:
        print("--- Turno ---")
        print(turno)

        bonus_dano = (turno * 3) / 1
        dano_total = ataque_base + bonus_dano - 2

        vida_chefe = vida_chefe - dano_total

        if vida_chefe > 0:
            print("Voce causou de dano:")
            print(dano_total)
            print("Vida restante do chefe:")
            print(vida_chefe)

        if vida_chefe <= 0:
            print("Dano critico!")
            print("O Chefe foi derrotado!")

        turno = turno + 1
else:
    print("O combate nao pode iniciar porque o chefe ja estava derrotado.")

print("Fim de jogo. Teste concluido com sucesso!")
