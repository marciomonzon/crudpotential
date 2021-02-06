import React, { ChangeEvent, useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';
import { Nav, Navbar, Table, Button, Form } from 'react-bootstrap';
import api from '../../services/Api';

interface IDesenvolvedor {
    nome: string,
    idade: string,
    sexo: string,
    hobby: string,
    dataDeNascimento: string
}

const FormularioDesenvolvedores: React.FC = () => {

    const history = useHistory();

    const [model, setModel] = useState<IDesenvolvedor>({
        nome: '',
        idade: '',
        sexo: '',
        hobby: '',
        dataDeNascimento: ''
    });

    function updatedModel(e: ChangeEvent<HTMLInputElement>) {
        setModel({
            ... model,
            [e.target.name]: e.target.value
        })
    }

    async function onSubmit(e: ChangeEvent<HTMLFormElement>) {
        e.preventDefault();

        const response = await api.post('/developers', model);
        console.log(response);
    }

    function voltar() {
        history.goBack();
    }

    return (
        <div className="container">
            <br/>
            <h3>Novo Desenvolvedor</h3>
            <br/>
            <div>
                <Button variant="dark" size="sm" onClick={voltar} >Voltar</Button>
            </div>
            <br/>

            <div className="container">
            <Form onSubmit={ onSubmit }>
                <Form.Group>
                    <Form.Label>Nome:</Form.Label>

                    <Form.Control type="text" 
                    maxLength={100} 
                    name="nome" 
                    onChange={(e: ChangeEvent<HTMLInputElement>) => updatedModel(e)}
                    />

                    <Form.Label>Idade:</Form.Label>
                    <Form.Control type="number" 
                    name="idade" 
                    onChange={(e: ChangeEvent<HTMLInputElement>) => updatedModel(e)}
                    />

                    <Form.Label>Sexo (M/F):</Form.Label>
                    <Form.Control type="text"  maxLength={1}
                    name="sexo" 
                    onChange={(e: ChangeEvent<HTMLInputElement>) => updatedModel(e)}
                    />
                    <Form.Label>Data de Nascimento:</Form.Label>
                    <Form.Control type="text"  
                    name="dataDeNascimento" 
                    onChange={(e: ChangeEvent<HTMLInputElement>) => updatedModel(e)}
                    />

                    <Form.Label>Hobby:</Form.Label>
                    <Form.Control type="text" maxLength={100}
                    name="hobby" 
                    onChange={(e: ChangeEvent<HTMLInputElement>) => updatedModel(e)}
                    />
                </Form.Group>
                <Button variant="primary" type="submit">
                    Cadastrar
                </Button>
            </Form>
            </div>
            
        </div>
    );
    
}

export default FormularioDesenvolvedores;