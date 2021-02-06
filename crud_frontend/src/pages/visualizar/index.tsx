import React, { useState, useEffect } from 'react';
import { Badge, Button, Card } from 'react-bootstrap';
import { useHistory, useParams } from 'react-router-dom';
import api from '../../services/Api';
import moment from 'moment';

interface IDesenvolvedor {
    nome: string,
    idade: string,
    sexo: string,
    hobby: string,
    dataDeNascimento: Date
}

interface IParamsProps {
    id: string;
}

const Detalhes: React.FC = () => {

    const history = useHistory()
    const { id } = useParams<IParamsProps>()
    const [desenv, setDesenv] = useState<IDesenvolvedor>()

    useEffect(() => {
        findTask()
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [id])

    function voltar() {
        history.goBack()
    }

    async function findTask() {
        const response = await api.get<IDesenvolvedor>(`/developers/${id}`)
        setDesenv(response.data)
    }

    function formateDate(date: Date | undefined) {
        return moment(date).format("DD/MM/YYYY")
    }

    return (
        <div className="container">
            <br/>
            <h3>Detalhes</h3>
            <br/>
            <div>
                <Button variant="dark" size="sm" onClick={ voltar }>Voltar</Button>
            </div>
            <br/>

            <Card>
                <Card.Body>
                    <Card.Title>{ desenv?.nome }</Card.Title>
                    <Card.Text>
                          Idade: { desenv?.idade } <br />
                          Sexo: { desenv?.sexo } <br />
                          Data de Nascimento: {desenv?.dataDeNascimento } <br />
                          Hobby: { desenv?.hobby } <br />
                    </Card.Text>
                </Card.Body>
            </Card>
            
        </div>
    );

}

export default Detalhes;