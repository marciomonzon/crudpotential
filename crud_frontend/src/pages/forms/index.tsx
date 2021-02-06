import React, { ChangeEvent, useEffect, useState } from 'react';
import { useHistory, useParams } from 'react-router-dom';
import { Nav, Navbar, Table, Button, Form } from 'react-bootstrap';
import api from '../../services/Api';

interface IDesenvolvedor {
    nome: string,
    idade: string,
    sexo: string,
    hobby: string,
    dataDeNascimento: string
}

interface IParamsProps {
    id: string;
}

const FormularioDesenvolvedores: React.FC = () => {

    const history = useHistory();
    const { id }= useParams<IParamsProps>();
    const [model, setModel] = useState<IDesenvolvedor>({
        nome: '',
        idade: '',
        sexo: '',
        hobby: '',
        dataDeNascimento: ''
    });

    useEffect(() => {
        if(id != undefined){
            obterDesenvolvedor(id);
        }
        
    }, [id]);

    function updatedModel(e: ChangeEvent<HTMLInputElement>) {
        setModel({
            ... model,
            [e.target.name]: e.target.value
        })
    }

    async function onSubmit(e: ChangeEvent<HTMLFormElement>) {
        e.preventDefault();

        if(id != undefined){
            const response = await api.put(`/developers/${id}`, model);
        }
        else{
            const response = await api.post('/developers', model);
        }

        voltar();
    }

    async function obterDesenvolvedor(id: string) {
        const response = await api.get(`/developers/${id}`);

        setModel({
            nome: response.data.nome,
            idade: response.data.idade,
            sexo: response.data.sexo,
            hobby: response.data.hobby,
            dataDeNascimento: response.data.dataDeNascimento
        })

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
                    value={model.nome} 
                    onChange={(e: ChangeEvent<HTMLInputElement>) => updatedModel(e)}
                    />

                    <Form.Label>Idade:</Form.Label>
                    <Form.Control type="number" 
                    name="idade" 
                    value={model.idade} 
                    onChange={(e: ChangeEvent<HTMLInputElement>) => updatedModel(e)}
                    />

                    <Form.Label>Sexo (M/F):</Form.Label>
                    <Form.Control type="text"  maxLength={1}
                    name="sexo" 
                    value={model.sexo} 
                    onChange={(e: ChangeEvent<HTMLInputElement>) => updatedModel(e)}
                    />
                    <Form.Label>Data de Nascimento:</Form.Label>
                    <Form.Control type="text"  
                    name="dataDeNascimento" 
                    value={model.dataDeNascimento} 
                    onChange={(e: ChangeEvent<HTMLInputElement>) => updatedModel(e)}
                    />

                    <Form.Label>Hobby:</Form.Label>
                    <Form.Control type="text" maxLength={100}
                    name="hobby" 
                    value={model.hobby} 
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