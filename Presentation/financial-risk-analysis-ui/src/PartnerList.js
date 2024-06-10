import React, { useEffect, useState } from 'react';

const PartnerList = () => {
    const host = 'http://localhost:5019/api/Partner/';
    const [partners, setPartners] = useState([]);
    const [form, setForm] = useState({
        name: '',
        pageIndex: 1,
        pageNumber: 1,
        pageSize: 20
    });
    const [partner, setPartner] = useState({
        name: ''
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
                    : "İş ortağı listesi getirilirken bir hata meydana geldi";

                alert(errorMessage);
            }

            setPartners(response.result.pagedList);
        })
        .catch(error => {
            console.log(error);
            alert("İş ortağı listesi getirilirken bir hata meydana geldi");
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

    const getPartnerForSet = (partner) => {
        setPartner(s => ({
            ...s,
            partnerId: partner.id,
            name: partner.name
        }));
    }

    const handleSetChange = (event) => {
        setPartner({
          ...partner,
          [event.target.id]: event.target.value,
        });
    };

    const handleSetSubmit = (event) => {
        event.preventDefault();
        putSetData();
    };

    const putSetData = async () => {
        await fetch(host + partner.partnerId,
        {
            method: 'PUT',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(partner)
        })
        .then(response => response.json())
        .then(response => {
            if (!response.isSuccessful) {
                var errorMessage = response.error != null
                    ? response.error.message
                    : "İş ortağı güncellenirken bir hata meydana geldi";

                alert(errorMessage);
            } else {
                alert("Güncelleme işlemi başarılı")
                fetchData();
            }
        })
        .catch(error => {
            console.log(error);
            alert("İş ortağı güncellenirken bir hata meydana geldi");
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
                                placeholder="İş Ortağı"
                                value={form.name}
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
                                <th>İş Ortağı</th>
                                <th>Oluşturulma</th>
                                <th>Güncelleme</th>
                            </tr>
                        </thead>
                        <tbody>
                            {partners.map(partner =>
                                <tr key={partner.id}>
                                    <td style={{textAlign: 'center'}}>
                                        <UpdateButton onClick={() => getPartnerForSet(partner)}></UpdateButton>
                                    </td>
                                    <td>{partner.name}</td>
                                    <td>{partner.createDate}</td>
                                    <td>{partner.updateDate}</td>
                                </tr>)}
                        </tbody>
                    </table>
                    
                    <div className="modal fade" id="updateModal" aria-labelledby="updateModalLabel" aria-hidden="true">
                        <div className="modal-dialog">
                            <div className="modal-content">
                                <div className="modal-header">
                                    <h1 className="modal-title fs-5" id="updateModalLabel">İş Ortağını Güncelle</h1>
                                    <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div className="modal-body">
                                    <form onSubmit={handleSetSubmit} >
                                        <input
                                            id="id"
                                            type="hidden"
                                            className="form-control"
                                            value={partner.id} />
                                        <div className="mb-3">
                                            <label htmlFor='name' className="form-label">İş Ortağı</label>
                                            <input
                                                id="name"
                                                type="text"
                                                className="form-control"
                                                value={partner.name}
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

export default PartnerList;