limite_inferior = 10
limite_superior = 15
numero_atual = limite_inferior
maior_sequencia = 0
numero_vencedor = 0

print("Calculando o problema de Collatz")
print("Testando de:")
print(limite_inferior)
print("Ate:")
print(limite_superior)

while numero_atual <= limite_superior:
    passos = 0
    n = numero_atual
    
    while n > 1:
        temp = n
        
        while temp >= 2:
            temp = temp - 2
            
        if temp == 0:
            dividendo = n
            quociente = 0
            
            while dividendo >= 2:
                dividendo = dividendo - 2
                quociente = quociente + 1
                
            n = quociente
            
        if temp == 1:
            n = (n * 3) + 1
            
        passos = passos + 1
        
    if passos > maior_sequencia:
        maior_sequencia = passos
        numero_vencedor = numero_atual
        
    print("Numero concluido:")
    print(numero_atual)
    print("Passos necessarios:")
    print(passos)
    
    numero_atual = numero_atual + 1

print("Vencedor (numero que demorou mais):")
print(numero_vencedor)
print("Passos do vencedor:")
print(maior_sequencia)

pontuacao = (numero_vencedor * maior_sequencia) / 2
print("Pontuacao final do teste (com multiplicacao e divisao):")
print(pontuacao)