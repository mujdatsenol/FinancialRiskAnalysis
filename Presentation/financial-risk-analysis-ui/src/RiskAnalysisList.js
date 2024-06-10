import React, { useEffect, useState } from 'react';

const RiskAnalysisList = () => {
    const host = 'http://localhost:5019/api/RiskAnalysis/';
    const [riskAnalyses, setRiskAnalyses] = useState([]);
    const [form, setForm] = useState({
        riskScore: null,
        pageIndex: 1,
        pageNumber: 1,
        pageSize: 20
    });
    const [riskAnalysis, setRiskAnalysis] = useState({
        riskScore: null
    });

    const handleChange = (event) => {
        setForm({
          ...form,
          [event.target.id]: event.target.value,
        });
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        fetchData();
    };

    const fetchData = async () => {
        await fetch(host + 'search',
        {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(form)
        })
        .then(response => response.json())
        .then(response => {
            if (!response.isSuccessful) {
                var errorMessage = response.error != null
                    ? response.error
                    : "Risk analizi listesi getirilirken bir hata meydana geldi";

                alert(errorMessage);
            }

            setRiskAnalyses(response.result.pagedList);
        })
        .catch(error => {
            console.log(error);
            alert("Risk analizi listesi getirilirken bir hata meydana geldi");
        });
    }

    const UpdateButton = ({ onClick }) => {
        return (
            <button
                type="button"
                className="btn btn-primary btn-sm"
                data-bs-toggle="modal"
                data-bs-target="#updateModal"
                onClick={onClick}>Güncelle</button>
        )
    }

    const getRiskAnalysisForSet = (riskAnalysis) => {
        setRiskAnalysis(s => ({
            ...s,
            riskAnalysisId: riskAnalysis.id,
            riskScore: riskAnalysis.riskScore
        }));
    }

    const handleSetChange = (event) => {
        setRiskAnalysis({
          ...riskAnalysis,
          [event.target.id]: event.target.value,
        });
    };

    const handleSetSubmit = (event) => {
        event.preventDefault();
        putSetData();
    };

    const putSetData = async () => {
        await fetch(host + riskAnalysis.riskAnalysisId,
        {
            method: 'PUT',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(riskAnalysis)
        })
        .then(response => response.json())
        .then(response => {
            if (!response.isSuccessful) {
                var errorMessage = response.error != null
                    ? response.error.message
                    : "Risk analizi güncellenirken bir hata meydana geldi";

                alert(errorMessage);
            } else {
                alert("Güncelleme işlemi başarılı")
                fetchData();
            }
        })
        .catch(error => {
            console.log(error);
            alert("Risk analizi güncellenirken bir hata meydana geldi");
        });
    }

    useEffect(() => 
    {
        fetchData();
    }, []);

    return(
        <div className='container'>
            <div className='row mt-3'>
                <div className='col'>
                    <form onSubmit={handleSubmit} className="row">
                        <div className="col-3">
                            <input
                                id="riskScore"
                                type="number"
                                className="form-control"
                                placeholder="Risk Skoru"
                                value={form.riskScore}
                                onChange={handleChange} />
                        </div>
                        <div className='col-3 d-grid'>
                            <button type="submit" className="btn btn-primary mb-3">Filtrele</button>
                        </div>
                    </form>
                    <table className="table table-striped table-hover table-bordered ">
                        <thead className='table-dark'>
                            <tr>
                                <th></th>
                                <th>Risk Skoru</th>
                                <th>Oluşturulma</th>
                                <th>Güncelleme</th>
                            </tr>
                        </thead>
                        <tbody>
                            {riskAnalyses.map(riskAnalysis =>
                                <tr key={riskAnalysis.id}>
                                    <td style={{textAlign: 'center'}}>
                                        <UpdateButton onClick={() => getRiskAnalysisForSet(riskAnalysis)}></UpdateButton>
                                    </td>
                                    <td>{riskAnalysis.riskScore}</td>
                                    <td>{riskAnalysis.createDate}</td>
                                    <td>{riskAnalysis.updateDate}</td>
                                </tr>)}
                        </tbody>
                    </table>
                    
                    <div className="modal fade" id="updateModal" aria-labelledby="updateModalLabel" aria-hidden="true">
                        <div className="modal-dialog">
                            <div className="modal-content">
                                <div className="modal-header">
                                    <h1 className="modal-title fs-5" id="updateModalLabel">Risk Skoru Güncelle</h1>
                                    <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div className="modal-body">
                                    <form onSubmit={handleSetSubmit} >
                                        <input
                                            id="id"
                                            type="hidden"
                                            className="form-control"
                                            value={riskAnalysis.id} />
                                        <div className="mb-3">
                                            <label htmlFor='riskScore' className="form-label">Risk Skoru</label>
                                            <input
                                                id="riskScore"
                                                type="text"
                                                className="form-control"
                                                value={riskAnalysis.riskScore}
                                                onChange={handleSetChange} />
                                        </div>
                                    </form>
                                </div>
                                <div className="modal-footer">
                                    <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Kapat</button>
                                    <button type="button" className="btn btn-primary" onClick={handleSetSubmit.bind(this)}>Güncelle</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
    )
};

export default RiskAnalysisList;