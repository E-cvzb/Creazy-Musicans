using Creazy_Musicans.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Creazy_Musicans.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrreazyMusicians : ControllerBase
    {
        public List<Musicians> _musicians = new List<Musicians>
        {

            new Musicians { Id=1,Name="Ahmet Çalgı",Job="Ünlü çalgı çalar",Feature="Her zaman yanlış nota çalar, ama çok eğlenceli"},
            new Musicians{ Id=2,Name="Zeynep Melodi",Job="Popiler Melodi Yazarı", Feature="Şarkılaır yanlış anlaşılır ama çok popiler"},
            new Musicians{ Id=3,Name="Cemil Akor",Job="Çılgın Akorist", Feature="Akorları sık değişir ama şaşırtıcı şekilde yetenikli"},
            new Musicians{ Id=4,Name="Fatma Nota ",Job="Süpriz Nota Üreticisi", Feature="Nota hazılarken sürekli süprizler hazırlar"},
            new Musicians{ Id=5,Name="Hasan Ritim",Job="Ritim Canavarı", Feature="Her ritimi kendi tarında hiç uymaz,ama komiktir"},
            new Musicians{ Id=6,Name="Elif Armoni",Job="Armoni Ustası", Feature="Armonileri bazen yanlış yazar,ama çok yaratıcı"},
            new Musicians{ Id=7,Name="Ali Perde",Job="Perde Uygulayıcı", Feature="Her perdeyı farklı şekilde çalar,her zaman süprizlidir"},
            new Musicians{ Id=8,Name="Ayşe Rezonans",Job="Rezonanas Uzmanı", Feature="Rezonans konsunda uzman,ama bazen çok gürültülü"},
            new Musicians{ Id=9,Name="Murat Ton",Job="Tonlama Markası", Feature="Tonlamalı farklıdır bazen komik,ama oldukça ilginç"},
            new Musicians{ Id=10,Name="Selim Akor",Job="Akor Sihirbazı", Feature="Akorlar değiştiğnde bazen sihirli bir hazva yaratır"},
        };

        [HttpGet]
        public IActionResult MusicianGet()//bütün verilerin okunması
        {
            return Ok(_musicians);
        }

        [HttpGet("{id:int:min(1)}")]//seçilen verinin okunması
        public IActionResult MusicianIdGet(int id)
        {

            var task = _musicians.FirstOrDefault(x => x.Id == id);
            if (task is null)
            {
                return NotFound();
            }

            return Ok(task);

        }

        [HttpGet("Serch")]// url içinde arama yapmak için query kullanılan serch kullanıln metot
        public IActionResult Search([FromQuery] int id, [FromQuery] string? job)
        {
            var task = _musicians.FirstOrDefault(x => x.Id == id);
            if (task is null)
                return BadRequest();
            return Ok(task);
        }

        [HttpPost]// Yeni veri girişi için post
        public IActionResult MusicianPost([FromBody] Musicians musicians)
        {
            int id = _musicians.Max(x => x.Id);

            musicians.Id = id;
            _musicians.Add(musicians);
            return CreatedAtAction(nameof(MusicianGet), new { id = musicians.Id }, musicians);


        }

        [HttpPut("{id}")]// Verilerin bütün özelliklerinin tekrardan sağlanamsı
        public IActionResult Edit(int id, [FromBody] Musicians editMusicians)
        {
            var task = _musicians.FirstOrDefault(x => x.Id == id);

            if (task is null)
                return BadRequest();


            task.Id = editMusicians.Id;
            task.Name = editMusicians.Name;
            task.Feature = editMusicians.Feature;
            task.Job = editMusicians.Job;

            return Ok(task);


        }
        [HttpPatch("{id}")]// task ı abc ye sadece job ile eşitleyerek tek bir özelliğin güncellenmesi sağlandı
        public IActionResult Patch (int id, [FromBody] Musicians patch)
        {
            var task = _musicians.FirstOrDefault(x=>x.Id==id);
            if(task is null)
                return NotFound();
           
            task.Job=patch.Job;
            return Ok(task);

        }
        [HttpDelete] //soft delete işlemi 
        public IActionResult Delete (int id)
        {
            var task = _musicians.FirstOrDefault(x => x.Id == id);
            if (task is null)
                return BadRequest();

            task.IsDelete = true;
            return NoContent();
        }






    }

}
