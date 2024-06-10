import React, { useEffect, useState } from 'react';

const BusinessContractList = () => {
    const host = 'http://localhost:5019/api/BusinessContract/';
    const [businessContracts, setBusinessContracts] = useState([]);
    const [form, setForm] = useState({
        name: '',
        description: '',
        pageIndex: 1,
        pageNumber: 1,
        pageSize: 20
    });
    const [businessContract, setBusinessContract] = useState({
        name: '',
        description: '',
        starDate: '',
        endDate: ''
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
                    : "İş anlaşması listesi getirilirken bir hata meydana geldi";

                alert(errorMessage);
            }

            setBusinessContracts(response.result.pagedList);
        })
        .catch(error => {
            console.log(error);
            alert("İş anlaşması listesi getirilirken bir hata meydana geldi");
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

    const getBusinessContractForSet = (businessContract) => {
        setBusinessContract(s => ({
            ...s,
            businessContractId: businessContract.id,
            name: businessContract.name,
            description: businessContract.description,
            starDate: businessContract.starDate,
            endDate: businessContract.endDate
        }));
    }

    const handleSetChange = (event) => {
        setBusinessContract({
          ...businessContract,
          [event.target.id]: event.target.value,
        });
    };

    const handleSetSubmit = (event) => {
        event.preventDefault();
        putSetData();
    };

    const putSetData = async () => {
        await fetch(host + businessContract.businessContractId,
        {
            method: 'PUT',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(businessContract)
        })
        .then(response => response.json())
        .then(response => {
            if (!response.isSuccessful) {
                var errorMessage = response.error != null
                    ? response.error.message
                    : "İş anlaşması güncellenirken bir hata meydana geldi";

                alert(errorMessage);
            } else {
                alert("Güncelleme işlemi başarılı")
                fetchData();
            }
        })
        .catch(error => {
            console.log(error);
            alert("İş anlaşması güncellenirken bir hata meydana geldi");
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
                                id="name"
                                type="text"
                                className="form-control"
                                placeholder="Anlaşma Adı"
                                value={form.name}
                                onChange={handleChange} />
                        </div>
                        <div className="col-3">
                            <input
                                id="description"
                                type="text"
                                className="form-control"
                                placeholder="Anlaşma Açıklaması"
                                value={form.description}
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
                                <th>Anlaşma Adı</th>
                                <th>Açıklama</th>
                                <th>Başlama</th>
                                <th>Bitiş</th>
                                <th>Oluşturulma</th>
                                <th>Güncelleme</th>
                            </tr>
                        </thead>
                        <tbody>
                            {businessContracts.map(businessContract =>
                                <tr key={businessContract.id}>
                                    <td style={{textAlign: 'center'}}>
                                        <UpdateButton onClick={() => getBusinessContractForSet(businessContract)}></UpdateButton>
                                    </td>
                                    <td>{businessContract.name}</td>
                                    <td>{businessContract.description}</td>
                                    <td>{businessContract.starDate}</td>
                                    <td>{businessContract.endDate}</td>
                                    <td>{businessContract.createDate}</td>
                                    <td>{businessContract.updateDate}</td>
                                </tr>)}
                        </tbody>
                    </table>
                    
                    <div className="modal fade" id="updateModal" aria-labelledby="updateModalLabel" aria-hidden="true">
                        <div className="modal-dialog">
                            <div className="modal-content">
                                <div className="modal-header">
                                    <h1 className="modal-title fs-5" id="updateModalLabel">İş Anlaşması Güncelle</h1>
                                    <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div className="modal-body">
                                    <form onSubmit={handleSetSubmit} >
                                        <input
                                            id="id"
                                            type="hidden"
                                            className="form-control"
                                            value={businessContract.id} />
                                        <div className="mb-3">
                                            <label htmlFor='name' className="form-label">Anlaşma Adı</label>
                                            <input
                                                id="name"
                                                type="text"
                                                className="form-control"
                                                value={businessContract.name}
                                                onChange={handleSetChange} />
                                            <label htmlFor='description' className="form-label">Açıklaması</label>
                                            <input
                                                id="description"
                                                type="text"
                                                className="form-control"
                                                value={businessContract.description}
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

export default BusinessContractList;