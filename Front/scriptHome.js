var url = 'https://localhost:7041/api/Usuario/'
var urlLivro = 'https://localhost:7041/api/Livro/'

function cadastrarUsuario()
{
	//validacao de alguns dos inputs
	
	if(!validaNome('nome-completo'))
	{
		return
	}
	
	if(!validaSenha('senha'))
	{
		return
	}
	
	if(!confirmaSenha('confirma-senha'))
	{
		return
	}
	
	//construcao do json que vai no body da criacao de usuario	
	
	let body =
	{
		'name':        document.getElementById('nome-completo').value,
		'email':       document.getElementById('email').value,
		'password':    document.getElementById('senha').value
	};
	
	//envio da requisicao usando a FETCH API
	
	//configuracao e realizacao do POST no endpoint "usuarios"
	fetch(url,
	{
		'method': 'POST',
		'redirect': 'follow',
		'headers':
		{
			'Content-Type': 'application/json',
			'Accept': 'application/json'
		},
		'body': JSON.stringify(body)
	})
	//checa se requisicao deu certo
	.then((response) =>
	{
		if(response.ok)
		{
			return response.text()
		}
		else
		{
			return response.text().then((text) =>
			{
				throw new Error(text)
			})
		}
	})
	//trata resposta
	.then((output) =>
	{
		console.log(output)
		alert('Cadastro efetuado! :D')
	})
	//trata erro
	.catch((error) =>
	{
		console.log(error)
		alert('Não foi possível efetuar o cadastro! :(')
	})
}

function cadastrarLivro()
{
	//validacao de alguns dos inputs
	

	//construcao do json que vai no body da criacao de usuario	
	
	let body =
	{
		'name':        	document.getElementById('nome-livro').value,
		'descricao':    document.getElementById('nome-descricao').value,
		'autor':    	document.getElementById('nome-autor').value,
		'editora':    	document.getElementById('nome-editora').value,
		'numPag':    	document.getElementById('numero-paginas').value,
		'biblioteca' :{
			'name' : 'Teca'
		}

	};
	
	//envio da requisicao usando a FETCH API
	
	//configuracao e realizacao do POST no endpoint "usuarios"
	fetch(urlLivro,
	{
		'method': 'POST',
		'redirect': 'follow',
		'headers':
		{
			'Content-Type': 'application/json',
			'Accept': 'application/json'
		},
		'body': JSON.stringify(body)
	})
	//checa se requisicao deu certo
	.then((response) =>
	{
		if(response.ok)
		{
			return response.text()
		}
		else
		{
			return response.text().then((text) =>
			{
				throw new Error(text)
			})
		}
	})
	//trata resposta
	.then((output) =>
	{
		console.log(output)
		alert('Cadastro efetuado! :D')
	})
	//trata erro
	.catch((error) =>
	{
		console.log(error)
		alert('Não foi possível efetuar o cadastro! :(')
	})
}

function validaNome(id)
{
	let divNome = document.getElementById(id)
	if(divNome.value.trim().split(' ').length >= 2)
	{
		//divNome.style.border = 0
		divNome.classList.remove('erro-input')
		return true
	}
	else
	{
		//divNome.style.border = 'solid 1px red'
		if(!divNome.classList.contains('erro-input'))
		{
			divNome.classList.add('erro-input')
		}
		return false
	}
}

function validaData(id)
{
	let divData = document.getElementById(id)
	if(divData.value.length > 0)
	{
		//divData.style.border = 0
		divData.classList.remove('erro-input')
		return true
	}
	else
	{
		//divData.style.border = 'solid 1px red'
		if(!divData.classList.contains('erro-input'))
		{
			divData.classList.add('erro-input')
		}
		return false
	}
}

function validaSenha(id)
{
	let divSenha = document.getElementById(id)
	
	let senha = divSenha.value
	
	let temTamanho   = senha.length >= 8
	let temMaiuscula = (/[A-Z]/).test(senha)
	let temMinuscula = (/[a-z]/).test(senha)
	let temNumero    = (/[0-9]/).test(senha)
	let temEspecial  = (/[!@#$%&*?{}<>_]/).test(senha)
	
	if(temTamanho && temMaiuscula && temMinuscula && temNumero && temEspecial)
	{
		//divSenha.style.border = 0
		divSenha.classList.remove('erro-input')
		confirmaSenha('confirma-senha')
		return true
	}
	else
	{
		//divSenha.style.border = 'solid 1px red'
		if(!divSenha.classList.contains('erro-input'))
		{
			divSenha.classList.add('erro-input')
		}
		confirmaSenha('confirma-senha')
		return false
	}
}

function confirmaSenha(id)
{
	let divConfirma = document.getElementById(id)
	let divSenha = document.getElementById('senha')
	
	if(divConfirma.value == divSenha.value)
	{
		//divConfirma.style.border = 0
		divConfirma.classList.remove('erro-input')
		return true
	}
	else
	{
		//divConfirma.style.border = 'solid 1px red'
		if(!divConfirma.classList.contains('erro-input'))
		{
			divConfirma.classList.add('erro-input')
		}
		return false
	}
}

function getLogradouro()
{
	fetch('https://viacep.com.br/ws/' + document.getElementById('cep').value + '/json')
	.then(response => response.json())
	.then((output) =>
	{
		document.getElementById('logradouro').value = output.logradouro
	})
	.catch(error => console.log(error))
}

function listarUsuario()
{
	//da um GET no endpoint "usuarios"
	fetch(url)
	.then(response => response.json())
	.then((usuarios) =>
	{
		//pega div que vai conter a lista de usuarios
		let listaUsuarios = document.getElementById('lista-usuarios')
		
		//limpa div
		while(listaUsuarios.firstChild)
		{
			listaUsuarios.removeChild(listaUsuarios.firstChild)
		}
		
		//preenche div com usuarios recebidos do GET
		for(let usuario of usuarios)
		{
			//cria div para as informacoes de um usuario
			let divUsuario = document.createElement('div')
			divUsuario.setAttribute('class', 'form')
			
			//pega o nome do usuario
			let divNome = document.createElement('input')
			divNome.placeholder = 'Nome Completo'
			divNome.value = usuario.name
			divUsuario.appendChild(divNome)
			
			//pega o email do usuario
			let divEmail = document.createElement('input')
			divEmail.placeholder = 'Email'
			divEmail.value = usuario.email
			divUsuario.appendChild(divEmail)
			
			//cria o botao para remover o usuario
			let btnRemover = document.createElement('button')
			btnRemover.innerHTML = 'Remover'
			btnRemover.onclick = u => removerUsuario(usuario.id)
			btnRemover.style.marginRight = '5px'
			
			//cria o botao para atualizar o usuario
			let btnAtualizar = document.createElement('button')
			btnAtualizar.innerHTML = 'Atualizar'
			btnAtualizar.onclick = u => atualizarUsuario(usuario.id, divNome, divEmail)
			btnAtualizar.style.marginLeft = '5px'
			
			//cria a div com os dois botoes
			let divBotoes = document.createElement('div')
			divBotoes.style.display = 'flex'
			divBotoes.appendChild(btnRemover)
			divBotoes.appendChild(btnAtualizar)
			divUsuario.appendChild(divBotoes)
			
			//insere a div do usuario na div com a lista de usuarios
			listaUsuarios.appendChild(divUsuario)
		}
	})
}


function listarLivros()
{
	//da um GET no endpoint "usuarios"
	fetch(urlLivro)
	.then(response => response.json())
	.then((livros) =>
	{
		//pega div que vai conter a lista de livros
		let listaLivros = document.getElementById('lista-livros')
		
		//limpa div
		while(listaLivros.firstChild)
		{
			listaLivros.removeChild(listaLivros.firstChild)
		}
		
		//preenche div com livros recebidos do GET
		for(let livro of livros)
		{
			//cria div para as informacoes de um usuario
			let divLivro = document.createElement('div')
			divLivro.setAttribute('class', 'form')
			
			//pega o nome do usuario
			let divNome = document.createElement('input')
			divNome.placeholder = 'Nome Livro'
			divNome.value = livro.name
			divLivro.appendChild(divNome)
			
			//pega a descricao do Livro
			let divDescricao = document.createElement('input')
			divDescricao.placeholder = 'Descrição'
			divDescricao.value = livro.descricao
			divLivro.appendChild(divDescricao)
			
			//pega o Autor do Livro
			let divAutor = document.createElement('input')
			divAutor.placeholder = 'Autor'
			divAutor.value = livro.autor
			divLivro.appendChild(divAutor)

			let divEditora = document.createElement('input')
			divEditora.placeholder = 'Editora'
			divEditora.value = livro.editora
			divLivro.appendChild(divEditora)

			let divNumPag = document.createElement('input')
			divNumPag.placeholder = 'Numero Paginas'
			divNumPag.value = livro.numPag
			divLivro.appendChild(divNumPag)
			
			//cria o botao para remover o livro
			let btnRemover = document.createElement('button')
			btnRemover.innerHTML = 'Remover'
			btnRemover.onclick = u => removerLivro(livro.id)
			btnRemover.style.marginRight = '5px'
			
			//cria o botao para atualizar o livro
			let btnAtualizar = document.createElement('button')
			btnAtualizar.innerHTML = 'Atualizar'
			btnAtualizar.onclick = u => atualizarLivro(livro.id,divNome, divDescricao, divAutor, divEditora,divNumPag)
			btnAtualizar.style.marginLeft = '5px'
			
			//cria a div com os dois botoes
			let divBotoes = document.createElement('div')
			divBotoes.style.display = 'flex'
			divBotoes.appendChild(btnRemover)
			divBotoes.appendChild(btnAtualizar)
			divLivro.appendChild(divBotoes)
			
			//insere a div do usuario na div com a lista de usuarios
			listaLivros.appendChild(divLivro)
		}
	})
}


//EXEMPLO DE FUNCAO QUE CRIA OPTION DE SELECAO DE USUARIOS
function foo()
{
	//da um GET no endpoint "usuarios"
	fetch(url + 'usuarios')
	.then(response => response.json())
	.then((usuarios) =>
	{
		//PEGA OPTION VAZIA NO HTML
		let selUsuarios = document.getElementById('option-usuarios')
				
		//PREENCHE ELA COM O NOME E O ID DOS USUARIOS
		for(let usuario of usuarios)
		{
			let optUsuario = document.createElement('option')
			optUsuario.innerHTML = usuario.nome
			optUsuario.value = usuario.id
			selUsuarios.appendChild(optUsuario)
		}
	})
}

function atualizarLivro(id,divNome, divDescricao, divAutor, divEditora,divNumPag)
{
	let body =
	{
		"id"	: id,
		'name':        	divNome.value,
		'descricao':    divDescricao.value,
		'autor':    	divAutor.value,
		'editora':    	divEditora.value,
		'numPag':    	divNumPag.value,
		"biblioteca": {
			"id": 0,
			"name": "string"
		  }
	}
	
	fetch(urlLivro,
	{
		'method': 'PUT',
		'redirect': 'follow',
		'headers':
		{
			'Content-Type': 'application/json',
			'Accept': 'application/json'
		},
		'body': JSON.stringify(body)
	})
	.then((response) =>
	{
		if(response.ok)
		{
			return response.text()
		}
		else
		{
			return response.text().then((text) =>
			{
				throw new Error(text)
			})
		}
	})
	.then((output) =>
	{
		listarLivros()
		console.log(output)
		alert('Livro atualizado! \\o/')
	})
	.catch((error) =>
	{
		console.log(error)
		alert('Não foi possível atualizar o Livro :/')
	})
}


function atualizarUsuario(id,divNome, divEmail)
{
	let body =
	{
		"id"	: id,
		'name':        	divNome.value,
		'email':    	divEmail.value,
		'password'		: ""
	}
	
	fetch(url,
	{
		'method': 'PUT',
		'redirect': 'follow',
		'headers':
		{
			'Content-Type': 'application/json',
			'Accept': 'application/json'
		},
		'body': JSON.stringify(body)
	})
	.then((response) =>
	{
		if(response.ok)
		{
			return response.text()
		}
		else
		{
			return response.text().then((text) =>
			{
				throw new Error(text)
			})
		}
	})
	.then((output) =>
	{
		listarUsuario()
		console.log(output)
		alert('Usuario atualizado! \\o/')
	})
	.catch((error) =>
	{
		console.log(error)
		alert('Não foi possível atualizar o Usuario :/')
	})
}


function removerLivro(id)
{
	fetch(urlLivro + id,
	{
		'method': 'DELETE',
		'redirect': 'follow'
	})
	.then((response) =>
	{
		if(response.ok)
		{
			return response.text()
		}
		else
		{
			return response.text().then((text) =>
			{
				throw new Error(text)
			})
		}
	})
	.then((output) =>
	{
		listarLivros()
		console.log(output)
		alert('Livro removido! >=]')
	})
	.catch((error) =>
	{
		console.log(error)
		alert('Não foi possível remover o Livro :/')
	})
}

function removerUsuario(id)
{
	fetch(url + id,
	{
		'method': 'DELETE',
		'redirect': 'follow'
	})
	.then((response) =>
	{
		if(response.ok)
		{
			return response.text()
		}
		else
		{
			return response.text().then((text) =>
			{
				throw new Error(text)
			})
		}
	})
	.then((output) =>
	{
		listarUsuario()
		console.log(output)
		alert('Usuario removido! >=]')
	})
	.catch((error) =>
	{
		console.log(error)
		alert('Não foi possível remover o Usuario :/')
	})
}
